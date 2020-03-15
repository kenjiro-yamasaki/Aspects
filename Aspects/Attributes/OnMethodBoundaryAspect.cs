﻿using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SoftCube.Aspects
{
    /// <summary>
    /// メソッド境界アスペクト。
    /// </summary>
    public abstract class OnMethodBoundaryAspect : MethodLevelAspect
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected OnMethodBoundaryAspect()
        {
        }

        #endregion

        #region メソッド

        #region アドバイスの注入

        /// <summary>
        /// アドバイスを注入します。
        /// </summary>
        /// <param name="targetMethod">ターゲットメソッド。</param>
        /// <param name="aspectAttribute">アスペクト属性。</param>
        sealed public override void InjectAdvice(MethodDefinition targetMethod, CustomAttribute aspectAttribute)
        {
            using var profile = Profiling.Profiler.Start($"{nameof(OnMethodBoundaryAspect)}.{nameof(InjectAdvice)}");

            var iteratorStateMachineAttribute = targetMethod.GetIteratorStateMachineAttribute();
            var asyncStateMachineAttribute    = targetMethod.GetAsyncStateMachineAttribute();

            if (iteratorStateMachineAttribute != null)
            {
                var stateMachineRewriter = new IteratorStateMachineRewriter(targetMethod, aspectAttribute, typeof(MethodExecutionArgs));
                var methodRewriter = new MethodRewriter(targetMethod, aspectAttribute);

                RewriteTargetMethod(stateMachineRewriter, methodRewriter);
                RewriteMoveNextMethod(stateMachineRewriter);

                /// アスペクト属性を削除します。
                targetMethod.CustomAttributes.Remove(aspectAttribute);
                targetMethod.CustomAttributes.Remove(iteratorStateMachineAttribute);
            }
            else if (asyncStateMachineAttribute != null)
            {
                var stateMachineRewriter = new AsyncStateMachineRewriter(targetMethod, aspectAttribute, typeof(MethodExecutionArgs));
                var methodRewriter = new MethodRewriter(targetMethod, aspectAttribute);

                RewriteTargetMethod(stateMachineRewriter, methodRewriter);
                RewriteMoveNextMethod(stateMachineRewriter);
                //RewriteMoveNextMethod(new AsyncStateMachineRewriter(targetMethod, aspectAttribute, typeof(MethodExecutionArgs)));

                /// アスペクト属性を削除します。
                targetMethod.CustomAttributes.Remove(aspectAttribute);
                targetMethod.CustomAttributes.Remove(asyncStateMachineAttribute);
            }
            else
            {
                RewriteTargetMethod(new MethodRewriter(targetMethod, aspectAttribute));

                /// アスペクト属性を削除します。
                targetMethod.CustomAttributes.Remove(aspectAttribute);
            }
        }

        #region 通常のメソッド

        /// <summary>
        /// ターゲットメソッドを書き換えます。
        /// </summary>
        /// <param name="rewriter">ターゲットメソッドの書き換え。</param>
        private void RewriteTargetMethod(MethodRewriter rewriter)
        {
            /// オリジナルターゲットメソッド (ターゲットメソッドの元々のコード) を生成します。
            rewriter.CreateOriginalTargetMethod();

            /// ターゲットメソッドを書き換えます。
            var targetMethod            = rewriter.TargetMethod;
            var originalTargetMethod    = rewriter.OriginalTargetMethod;
            var aspectAttribute         = rewriter.AspectAttribute;
            var aspectAttributeType     = rewriter.AspectAttributeType;

            var aspectAttributeVariable = targetMethod.AddVariable(aspectAttributeType);
            var argumentsVariable       = targetMethod.AddVariable(typeof(Arguments));
            var aspectArgsVariable      = targetMethod.AddVariable(typeof(MethodExecutionArgs));
            var exceptionVariable       = targetMethod.AddVariable(typeof(Exception));

            var onEntry = new Action<ILProcessor>(processor =>
            {
                /// var aspectAttribute = new AspectAttribute(...) {...};
                /// var arguments       = new Arguments(...);
                /// var aspectArgs      = new MethodExecutionArgs(this, arguments);
                /// aspectArgs.Method = MethodBase.GetCurrentMethod();
                /// aspectAttribute.OnEntry(aspectArgs);
                /// arg0 = (TArg0)arguments[0];
                /// arg1 = (TArg1)arguments[1];
                /// ...
                processor.NewAspectAttribute(aspectAttribute);
                processor.Store(aspectAttributeVariable);

                processor.NewArguments();
                processor.Store(argumentsVariable);

                if (targetMethod.IsStatic)
                {
                    processor.LoadNull();
                }
                else
                {
                    processor.LoadThis();
                }
                processor.Load(argumentsVariable);
                processor.New(typeof(MethodExecutionArgs), typeof(object), typeof(Arguments));
                processor.Store(aspectArgsVariable);

                processor.Load(aspectArgsVariable);
                processor.CallStatic(typeof(MethodBase), nameof(MethodBase.GetCurrentMethod));
                processor.SetProperty(typeof(MethodArgs), nameof(MethodArgs.Method));

                processor.Load(aspectAttributeVariable);
                processor.Load(aspectArgsVariable);
                processor.CallVirtual(aspectAttributeType, nameof(OnEntry));
                processor.UpdateArguments(argumentsVariable, pointerOnly: false);
            });

            var onInvoke = new Action<ILProcessor>(processor =>
            {
                /// var returnValue = OriginalMethod(arg0, arg1, ...);
                /// aspectArgs.ReturnValue = returnValue;
                /// arguments[0] = arg0;
                /// arguments[1] = arg1;
                /// ...
                /// aspectAttribute.OnSuccess(aspectArgs);
                if (targetMethod.HasReturnValue())
                {
                    processor.Load(aspectArgsVariable);
                    processor.LoadThis();
                    processor.LoadArguments();
                    processor.Call(originalTargetMethod);
                    processor.Box(targetMethod.ReturnType);
                    processor.SetProperty(typeof(MethodArgs), nameof(MethodArgs.ReturnValue));
                }
                else
                {
                    processor.LoadThis();
                    processor.LoadArguments();
                    processor.Call(originalTargetMethod);
                }
                processor.UpdateArgumentsProperty(argumentsVariable, pointerOnly: true);

                processor.Load(aspectAttributeVariable);
                processor.Load(aspectArgsVariable);
                processor.CallVirtual(aspectAttributeType, nameof(OnSuccess));
            });

            var onException = new Action<ILProcessor>(processor =>
            {
                /// aspectArgs.Exception = ex;
                /// aspectAttribute.OnException(aspectArgs);
                /// rethrow;
                processor.Store(exceptionVariable);
                processor.Load(aspectArgsVariable);
                processor.Load(exceptionVariable);
                processor.SetProperty(typeof(MethodArgs), nameof(MethodArgs.Exception));

                processor.Load(aspectAttributeVariable);
                processor.Load(aspectArgsVariable);
                processor.CallVirtual(aspectAttributeType, nameof(OnException));
                processor.Rethrow();
            });

            var onExit = new Action<ILProcessor>(processor =>
            {
                /// aspectAttribute.OnExit(aspectArgs);
                /// arg0 = (TArg0)arguments[0];
                /// arg1 = (TArg1)arguments[1];
                /// ...
                processor.Load(aspectAttributeVariable);
                processor.Load(aspectArgsVariable);
                processor.CallVirtual(aspectAttributeType, nameof(OnExit));
                processor.UpdateArguments(argumentsVariable, pointerOnly: true);
            });

            var onReturn = new Action<ILProcessor>(processor =>
            {
                /// return (TResult)aspectArgs.ReturnValue;
                if (targetMethod.HasReturnValue())
                {
                    processor.Load(aspectArgsVariable);
                    processor.GetProperty(typeof(MethodArgs), nameof(MethodArgs.ReturnValue));
                    processor.Unbox(targetMethod.ReturnType);
                }
                processor.Return();
            });

            rewriter.RewriteMethod(onEntry, onInvoke, onException, onExit, onReturn);
        }

        #endregion

        #region イテレーターメソッド

        /// <summary>
        /// ターゲットメソッドを書き換えます。
        /// </summary>
        /// <param name="stateMachineRewriter">イテレーターステートマシンの書き換え。</param>
        /// <param name="methodRewriter">ターゲットメソッドの書き換え。</param>
        private void RewriteTargetMethod(IteratorStateMachineRewriter stateMachineRewriter, MethodRewriter methodRewriter)
        {
            var targetMethod = methodRewriter.TargetMethod;
            if (stateMachineRewriter.ThisField == null && !targetMethod.IsStatic)
            {
                var module = stateMachineRewriter.Module;
                var thisField = stateMachineRewriter.CreateField("<>4__this", Mono.Cecil.FieldAttributes.Public, module.ImportReference(methodRewriter.TargetMethod.DeclaringType));

                targetMethod.Body = new Mono.Cecil.Cil.MethodBody(targetMethod);
                var processor = targetMethod.Body.GetILProcessor();

                processor.Emit(OpCodes.Ldc_I4, -2);
                processor.New(stateMachineRewriter.StateMachineType);
                processor.Emit(OpCodes.Dup);
                processor.Emit(OpCodes.Ldarg_0);
                processor.Store(thisField);

                var parameters = targetMethod.Parameters;
                for (int parameterIndex = 0; parameterIndex < parameters.Count; parameterIndex++)
                {
                    var parameter = parameters[parameterIndex];

                    processor.Emit(OpCodes.Dup);
                    processor.Emit(OpCodes.Ldarg, parameterIndex + 1);
                    processor.Store(stateMachineRewriter.GetField("<>3__" + parameter.Name));
                }

                processor.Emit(OpCodes.Ret);
            }
        }

        /// <summary>
        /// MoveNext メソッドを書き換えます。
        /// </summary>
        /// <param name="stateMachineRewriter">イテレーターステートマシンの書き換え。</param>
        private void RewriteMoveNextMethod(IteratorStateMachineRewriter stateMachineRewriter)
        {
            var module               = stateMachineRewriter.Module;
            var aspectAttribute      = stateMachineRewriter.AspectAttribute;
            var aspectAttributeType  = stateMachineRewriter.AspectAttributeType;
            var aspectArgsType       = stateMachineRewriter.AspectArgsType;
            var moveNextMethod       = stateMachineRewriter.MoveNextMethod;
            var targetMethod         = stateMachineRewriter.TargetMethod;
            var stateMachineType     = stateMachineRewriter.StateMachineType;

            var thisField            = stateMachineRewriter.ThisField;
            var currentField         = stateMachineRewriter.CurrentField;
            var aspectAttributeField = stateMachineRewriter.CreateField("*aspect", Mono.Cecil.FieldAttributes.Private, module.ImportReference(aspectAttribute.AttributeType));
            var argumentsField       = stateMachineRewriter.CreateField("*arguments", Mono.Cecil.FieldAttributes.Private, module.ImportReference(typeof(Arguments)));
            var aspectArgsField      = stateMachineRewriter.CreateField("*aspectArgs", Mono.Cecil.FieldAttributes.Private, module.ImportReference(aspectArgsType));
            int exceptionVariable    = -1;

            var onEntry = new Action<ILProcessor>(processor =>
            {
                /// _aspectAttribute = new AspectAttribute(...) {...};
                /// _arguments       = new Arguments(...);
                /// _aspectArgs      = new MethodExecutionArgs(<>4__this, _arguments);
                /// _aspectAttribute.OnEntry(_aspectArgs);
                /// arg0 = _arguments.Arg0;
                /// arg1 = _arguments.Arg1;
                /// ...
                processor.LoadThis();
                processor.NewAspectAttribute(aspectAttribute);
                processor.Store(aspectAttributeField);

                processor.LoadThis();
                processor.NewArguments(targetMethod);
                processor.Store(argumentsField);

                processor.LoadThis();
                if (targetMethod.IsStatic)
                {
                    processor.LoadNull();
                }
                else
                {
                    processor.LoadThis();
                    processor.Load(thisField);
                    processor.Box(targetMethod.DeclaringType);
                }
                processor.LoadThis();
                processor.Load(argumentsField);
                processor.New(typeof(MethodExecutionArgs), typeof(object), typeof(Arguments));
                processor.Store(aspectArgsField);

                processor.LoadThis();
                processor.Load(aspectAttributeField);
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.CallVirtual(aspectAttributeType, nameof(OnEntry));
                processor.UpdateArguments(argumentsField, targetMethod);
            });

            var onResume = new Action<ILProcessor>(processor =>
            {
                /// _aspectAttribute.OnResume(_aspectArgs);
                /// arg0 = _arguments.Arg0;
                /// arg1 = _arguments.Arg1;
                /// ...
                processor.LoadThis();
                processor.Load(aspectAttributeField);
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.CallVirtual(aspectAttributeType, nameof(OnResume));
                processor.UpdateArguments(argumentsField, targetMethod);
            });

            var onYield = new Action<ILProcessor>(processor =>
            {
                /// _aspectArgs.YieldValue = <> 2__current;
                /// _aspectAttribute.OnYield(_aspectArgs);
                /// <>2__current = (TResult)_aspectArgs.YieldValue;
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.LoadThis();
                processor.Load(currentField);
                processor.Box(currentField.FieldType);
                processor.SetProperty(typeof(MethodExecutionArgs), nameof(MethodExecutionArgs.YieldValue));

                processor.LoadThis();
                processor.Load(aspectAttributeField);
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.CallVirtual(aspectAttributeType, nameof(OnYield));

                processor.LoadThis();
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.GetProperty(typeof(MethodExecutionArgs), nameof(MethodExecutionArgs.YieldValue));
                processor.Unbox(currentField.FieldType);
                processor.Store(currentField);
            });

            var onSuccess = new Action<ILProcessor>(processor =>
            {
                /// _aspectAttribute.OnSuccess(_aspectArgs);
                processor.LoadThis();
                processor.Load(aspectAttributeField);
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.CallVirtual(aspectAttributeType, nameof(OnSuccess));
            });

            var onException = new Action<ILProcessor>(processor =>
            {
                /// _aspectArgs.Exception = exception;
                /// _aspectAttribute.OnException(_aspectArgs);
                exceptionVariable = moveNextMethod.AddVariable(typeof(Exception));
                processor.Store(exceptionVariable);

                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.Load(exceptionVariable);
                processor.SetProperty(typeof(MethodArgs), nameof(MethodArgs.Exception));

                processor.LoadThis();
                processor.Load(aspectAttributeField);
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.CallVirtual(aspectAttributeType, nameof(OnException));
            });

            var onExit = new Action<ILProcessor>(processor =>
            {
                /// _aspectAttribute.OnExit(_aspectArgs);
                processor.LoadThis();
                processor.Load(aspectAttributeField);
                processor.LoadThis();
                processor.Load(aspectArgsField);
                processor.CallVirtual(aspectAttributeType, nameof(OnExit));
            });

            stateMachineRewriter.RewriteMoveNextMethod(onEntry, onResume, onYield, onSuccess, onException, onExit);
        }

        #endregion

        #region 非同期メソッド

        /// <summary>
        /// ターゲットメソッドを書き換えます。
        /// </summary>
        /// <param name="stateMachineRewriter">イテレーターステートマシンの書き換え。</param>
        /// <param name="methodRewriter">ターゲットメソッドの書き換え。</param>
        private void RewriteTargetMethod(AsyncStateMachineRewriter stateMachineRewriter, MethodRewriter methodRewriter)
        {
            var targetMethod = methodRewriter.TargetMethod;
            if (stateMachineRewriter.ThisField == null && !targetMethod.IsStatic)
            {
                var module           = stateMachineRewriter.Module;
                var thisField        = stateMachineRewriter.CreateField("<>4__this", Mono.Cecil.FieldAttributes.Public, module.ImportReference(methodRewriter.TargetMethod.DeclaringType));
                var stateMachineType = stateMachineRewriter.StateMachineType.ToSystemType();
                var builderType      = typeof(AsyncTaskMethodBuilder);

                targetMethod.Body = new Mono.Cecil.Cil.MethodBody(targetMethod);
                var stateMachineVariable = targetMethod.AddVariable(stateMachineRewriter.StateMachineType);
                var builderVariable      = targetMethod.AddVariable(builderType);
                var builderField         = stateMachineRewriter.GetField("<>t__builder");

                var processor = targetMethod.Body.GetILProcessor();
                processor.Emit(OpCodes.Ldloca, stateMachineVariable);
                processor.Emit(OpCodes.Call, module.ImportReference(typeof(AsyncTaskMethodBuilder).GetMethod(nameof(AsyncTaskMethodBuilder.Create))));
                processor.Emit(OpCodes.Stfld, builderField);

                processor.Emit(OpCodes.Ldloca, stateMachineVariable);
                processor.Emit(OpCodes.Ldc_I4_M1);
                processor.Emit(OpCodes.Stfld, stateMachineRewriter.GetField("<>1__state"));

                processor.Emit(OpCodes.Ldloca, stateMachineVariable);
                processor.Emit(OpCodes.Ldarg_0);
                processor.Store(thisField);

                var parameters = targetMethod.Parameters;
                for (int parameterIndex = 0; parameterIndex < parameters.Count; parameterIndex++)
                {
                    var parameter = parameters[parameterIndex];

                    processor.Emit(OpCodes.Ldloca, stateMachineVariable);
                    processor.Emit(OpCodes.Ldarg, parameterIndex + 1);
                    processor.Store(stateMachineRewriter.GetField(parameter.Name));
                }

                processor.Emit(OpCodes.Ldloc, stateMachineVariable);
                processor.Emit(OpCodes.Ldfld, builderField);
                processor.Emit(OpCodes.Stloc, builderVariable);

                processor.Emit(OpCodes.Ldloca, builderVariable);
                processor.Emit(OpCodes.Ldloca, stateMachineVariable);
                processor.Call(module.ImportReference(builderType.GetMethod("Start").MakeGenericMethod(stateMachineType)));
                processor.Emit(OpCodes.Ldloca, stateMachineVariable);
                processor.LoadAddress(builderField);
                processor.Call(module.ImportReference(builderType.GetProperty("Task").GetGetMethod()));
                processor.Return();
            }
        }

        /// <summary>
        /// MoveNext メソッドを書き換えます。
        /// </summary>
        /// <param name="stateMachineRewriter">非同期ステートマシンの書き換え。</param>
        private void RewriteMoveNextMethod(AsyncStateMachineRewriter stateMachineRewriter)
        {
            var module               = stateMachineRewriter.Module;
            var aspectAttribute      = stateMachineRewriter.AspectAttribute;
            var aspectAttributeType  = stateMachineRewriter.AspectAttributeType;
            var aspectArgsType       = stateMachineRewriter.AspectArgsType;
            var moveNextMethod       = stateMachineRewriter.MoveNextMethod;
            var targetMethod         = stateMachineRewriter.TargetMethod;
            var stateMachineType     = stateMachineRewriter.StateMachineType;

            var thisField            = stateMachineRewriter.ThisField;
            var aspectAttributeField = stateMachineRewriter.CreateField("*aspect", Mono.Cecil.FieldAttributes.Private, module.ImportReference(aspectAttribute.AttributeType));
            var argumentsField       = stateMachineRewriter.CreateField("*arguments", Mono.Cecil.FieldAttributes.Private, module.ImportReference(typeof(Arguments)));
            var aspectArgsField      = stateMachineRewriter.CreateField("*aspectArgs", Mono.Cecil.FieldAttributes.Private, module.ImportReference(aspectArgsType));
            var exceptionVariable    = moveNextMethod.AddVariable(typeof(Exception));

            var onEntry = new Action<ILProcessor, Instruction>((processor, insert) =>
            {
                /// _aspectAttribute = new AspectAttribute(...) {...};
                /// _arguments       = new Arguments(...);
                /// _aspectArgs      = new MethodExecutionArgs(4__this, _arguments);
                /// _aspectAttribute.OnEntry(_aspectArgs);
                /// arg0 = _arguments.Arg0;
                /// arg1 = _arguments.Arg1;
                /// ...
                processor.LoadThis(insert);
                processor.NewAspectAttribute(insert, aspectAttribute);
                processor.Store(insert, aspectAttributeField);

                processor.LoadThis(insert);
                processor.NewArguments(insert, targetMethod);
                processor.Store(insert, argumentsField);

                processor.LoadThis(insert);
                if (targetMethod.IsStatic)
                {
                    processor.LoadNull(insert);
                }
                else
                {
                    processor.LoadThis(insert);
                    processor.Load(insert, thisField);
                    processor.Box(insert, targetMethod.DeclaringType);
                }
                processor.LoadThis(insert);
                processor.Load(insert, argumentsField);
                processor.New<MethodExecutionArgs>(insert, typeof(object), typeof(Arguments));
                processor.Store(insert, aspectArgsField);

                processor.LoadThis(insert);
                processor.Load(insert, aspectAttributeField);
                processor.LoadThis(insert);
                processor.Load(insert, aspectArgsField);
                processor.CallVirtual(insert, aspectAttributeType, nameof(OnEntry));
                processor.UpdateArguments(insert, argumentsField, targetMethod);
            });

            var onResume = new Action<ILProcessor, Instruction>((processor, insert) =>
            {
                /// _aspectAttribute.OnResume(_aspectArgs);
                /// arg0 = _arguments.Arg0;
                /// arg1 = _arguments.Arg1;
                /// ...
                processor.LoadThis(insert);
                processor.Load(insert, aspectAttributeField);
                processor.LoadThis(insert);
                processor.Load(insert, aspectArgsField);
                processor.CallVirtual(insert, aspectAttributeType, nameof(OnResume));
                processor.UpdateArguments(insert, argumentsField, targetMethod);
            });

            var onYield = new Action<ILProcessor, Instruction>((processor, insert) =>
            {
                /// _aspectAttribute.OnYield(_aspectArgs);
                processor.LoadThis(insert);
                processor.Load(insert, aspectAttributeField);
                processor.LoadThis(insert);
                processor.Load(insert, aspectArgsField);
                processor.CallVirtual(insert, aspectAttributeType, nameof(OnYield));
            });

            var onSuccess = new Action<ILProcessor, Instruction>((processor, insert) =>
            {
                /// _aspectArgs.ReturnValue = result;
                /// _aspectAttribute.OnSuccess(_aspectArgs);
                /// result = (TResult)_aspectArgs.ReturnValue;
                int resultVariable = 1;
                if (targetMethod.ReturnType is GenericInstanceType genericReturnType)
                {
                    var returnType = genericReturnType.GenericArguments[0];
                    processor.LoadThis(insert);
                    processor.Load(insert, aspectArgsField);
                    processor.Load(insert, resultVariable);
                    processor.Box(insert, returnType);
                    processor.SetProperty(insert, typeof(MethodArgs), nameof(MethodArgs.ReturnValue));

                    processor.LoadThis(insert);
                    processor.Load(insert, aspectAttributeField);
                    processor.LoadThis(insert);
                    processor.Load(insert, aspectArgsField);
                    processor.CallVirtual(insert, aspectAttributeType, nameof(OnSuccess));

                    processor.LoadThis(insert);
                    processor.Load(insert, aspectArgsField);
                    processor.GetProperty(insert, typeof(MethodArgs), nameof(MethodArgs.ReturnValue));
                    processor.Unbox(insert, returnType);
                    processor.Store(insert, resultVariable);
                }
                else
                {
                    processor.LoadThis(insert);
                    processor.Load(insert, aspectAttributeField);
                    processor.LoadThis(insert);
                    processor.Load(insert, aspectArgsField);
                    processor.CallVirtual(insert, aspectAttributeType, nameof(OnSuccess));
                }
            });

            var onException = new Action<ILProcessor, Instruction>((processor, insert) =>
            {
                /// _aspectArgs.Exception = exception;
                /// _aspectAttribute.OnException(_aspectArgs);
                processor.Store(insert, exceptionVariable);
                processor.LoadThis(insert);
                processor.Load(insert, aspectArgsField);
                processor.Load(insert, exceptionVariable);
                processor.SetProperty(insert, typeof(MethodArgs), nameof(MethodArgs.Exception));

                processor.LoadThis(insert);
                processor.Load(insert, aspectAttributeField);
                processor.LoadThis(insert);
                processor.Load(insert, aspectArgsField);
                processor.CallVirtual(insert, aspectAttributeType, nameof(OnException));
            });

            var onExit = new Action<ILProcessor, Instruction>((processor, insert) =>
            {
                /// _aspectAttribute.OnExit(_aspectArgs);
                processor.LoadThis(insert);
                processor.Load(insert, aspectAttributeField);
                processor.LoadThis(insert);
                processor.Load(insert, aspectArgsField);
                processor.CallVirtual(insert, aspectAttributeType, nameof(OnExit));
            });

            stateMachineRewriter.RewriteMoveNextMethod(onEntry, onResume, onYield, onSuccess, onException, onExit);
        }

        #endregion

        #endregion

        #region イベントハンドラー

        /// <summary>
        /// メッソドが開始されたときに呼びだされます。
        /// </summary>
        /// <param name="args">メソッド実行引数。</param>
        public virtual void OnEntry(MethodExecutionArgs args)
        {
        }

        /// <summary>
        /// <c>yield return</c> または <c>await</c> ステートメントの結果として、ステートマシンが結果を出力するときに呼びだされます。
        /// </summary>
        /// <param name="args">メソッド実行引数。</param>
        /// <remarks>
        /// イテレーターメソッドでは、アドバイスは <c>yield return</c> ステートメントで呼びだされます。
        /// 非同期メソッドでは、<c>await</c> ステートメントの結果としてステートマシンが待機を開始した直後にアドバイスが呼びだされます。
        /// <c>await</c> ステートメントのオペランドが同期的に完了した操作である場合、ステートマシンは結果を出力せず、<see cref="OnYield(MethodExecutionArgs)"/> アドバイスは呼び出されません。
        /// </remarks>
        public virtual void OnYield(MethodExecutionArgs args)
        {
        }

        /// <summary>
        /// <c>yield return</c> または <c>await</c> ステートメントの後にステートマシンが実行を再開するときに呼びだされます。
        /// </summary>
        /// <param name="args">メソッド実行引数。</param>
        /// <remarks>
        /// イテレーターメソッドの場合、このアドバイスは MoveNext() メソッドの前に呼びだされます。
        /// ただし、MoveNext() の最初の呼び出しは <see cref="OnEntry(MethodExecutionArgs)"/> にマップされます。
        /// 非同期メソッドでは、<c>await</c> ステートメントの結果として待機した後、ステートマシンが実行を再開した直後にアドバイスが呼びだされます。
        /// </remarks>
        public virtual void OnResume(MethodExecutionArgs args)
        {
        }

        /// <summary>
        /// メッソドが正常終了したときに呼びだされます。
        /// </summary>
        /// <param name="args">メソッド実行引数。</param>
        public virtual void OnSuccess(MethodExecutionArgs args)
        {
        }

        /// <summary>
        /// メッソドが例外終了したときに呼びだされます。
        /// </summary>
        /// <param name="args">メソッド実行引数。</param>
        public virtual void OnException(MethodExecutionArgs args)
        {
        }

        /// <summary>
        /// メッソドが終了したときに呼びだされます。
        /// </summary>
        /// <param name="args">メソッド実行引数。</param>
        public virtual void OnExit(MethodExecutionArgs args)
        {
        }

        #endregion

        #endregion
    }
}
