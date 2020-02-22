﻿using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SoftCube.Aspects
{
    /// <summary>
    /// 非同期ステートマシン。
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class MethodInterceptionAsyncStateMachine<TResult> : IAsyncStateMachine
    {
        #region フィールド

        /// <summary>
        /// 非同期タスクメソッドビルダー。
        /// </summary>
        public AsyncTaskMethodBuilder<TResult> Builder { get; }

        /// <summary>
        /// ステート。
        /// </summary>
        private int State;

        /// <summary>
        /// 非同期タスク。
        /// </summary>
        private Task Task;

        /// <summary>
        /// 非同期タスクが完了するまで待機するオブジェクト。
        /// </summary>
        private TaskAwaiter TaskAwaiter;

        /// <summary>
        /// アスペクト。
        /// </summary>
        private MethodInterceptionAspect Aspect;

        /// <summary>
        /// アスペクト引数。
        /// </summary>
        private MethodInterceptionArgs AspectArgs;

        #endregion

        #region コンストラクター

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="aspect">アスペクト。</param>
        /// <param name="aspectArgs">アスペクト引数。</param>
        public MethodInterceptionAsyncStateMachine(MethodInterceptionAspect aspect, MethodInterceptionArgs aspectArgs)
        {
            Builder    = AsyncTaskMethodBuilder<TResult>.Create();
            State      = -1;
            Aspect     = aspect ?? throw new ArgumentNullException(nameof(aspect));
            AspectArgs = aspectArgs ?? throw new ArgumentNullException(nameof(aspectArgs));
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 次のステートに遷移します。
        /// </summary>
        private void MoveNext()
        {
            TResult result;
            try
            {
                TaskAwaiter taskAwaiter;
                if (State != 0)
                {
                    Task = Aspect.OnInvokeAsync(AspectArgs);

                    taskAwaiter = Task.GetAwaiter();
                    if (!taskAwaiter.IsCompleted)
                    {
                        State = 0;
                        TaskAwaiter = taskAwaiter;

                        var stateMachine = this;
                        Builder.AwaitUnsafeOnCompleted(ref taskAwaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    taskAwaiter = TaskAwaiter;

                    TaskAwaiter = default;
                    State = -1;
                }
                taskAwaiter.GetResult();
                result =  (TResult)AspectArgs.ReturnValue;
            }
            catch (Exception exception)
            {
                State = -2;
                Builder.SetException(exception);
                return;
            }

            State = -2;
            Builder.SetResult(result);
        }

        #region IAsyncStateMachine

        /// <summary>
        /// 次のステートに遷移します。
        /// </summary>
        void IAsyncStateMachine.MoveNext()
        {
            MoveNext();
        }

        /// <summary>
        /// ステートマシンを設定します。
        /// </summary>
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        #endregion

        #endregion
    }
}
