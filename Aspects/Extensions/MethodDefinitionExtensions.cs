﻿using Mono.Cecil;
using Mono.Cecil.Cil;
using SoftCube.Log;
using System.Linq;

namespace SoftCube.Aspects
{
    /// <summary>
    /// <see cref="MethodDefinition"/> の拡張メソッド。
    /// </summary>
    public static class MethodDefinitionExtensions
    {
        #region メソッド

        #region プロパティに相当する拡張メソッド

        /// <summary>
        /// 戻り値が存在するかを判断します。
        /// </summary>
        /// <param name="method">メソッド定義。</param>
        /// <returns>戻り値が存在するか。</returns>
        public static bool HasReturnValue(this MethodDefinition method)
        {
            return method.ReturnType.FullName != "System.Void";
        }

        /// <summary>
        /// Return 命令を取得します。
        /// </summary>
        /// <param name="method">メソッド定義。</param>
        /// <returns>
        /// Return 命令。
        /// メソッドに戻り値がある場合、戻り値のロード命令を返します。
        /// メソッドに戻り値がない場合、Return 命令そのものを返します。
        /// </returns>
        public static Instruction ReturnInstruction(this MethodDefinition method)
        {
            var instructions = method.Body.Instructions;                                            // 命令コレクション。
            if (method.HasReturnValue())
            {
                return instructions.Last().Previous;
            }
            else
            {
                return instructions.Last();
            }
        }

        #endregion

        /// <summary>
        /// アスペクト (カスタムコード) を注入します。
        /// </summary>
        /// <param name="method">メソッド定義。</param>
        public static void Inject(this MethodDefinition method)
        {
            var baseFullName  = $"{nameof(SoftCube)}.{nameof(Aspects)}.{nameof(MethodLevelAspect)}";
            var baseScopeName = $"{nameof(SoftCube)}.{nameof(Aspects)}.dll";

            foreach (var attribute in method.CustomAttributes)
            {
                var baseAttributeType = attribute.AttributeType.Resolve().BaseType.Resolve();

                while (baseAttributeType != null && baseAttributeType.BaseType != null)
                {
                    if (baseAttributeType.FullName == baseFullName && baseAttributeType.Scope.Name == baseScopeName)
                    {
                        var aspect = attribute.Create<MethodLevelAspect>();
                        aspect.Inject(method);
                        break;
                    }

                    baseAttributeType = baseAttributeType.BaseType.Resolve();
                }
            }
        }

        /// <summary>
        /// IL コードを最適化します。
        /// </summary>
        /// <param name="method">メソッド定義。</param>
        public static void OptimizeIL(this MethodDefinition method)
        {
            var processor = method.Body.GetILProcessor();

            int offset = 0;
            foreach (var instruction in processor.Body.Instructions)
            {
                instruction.Offset = offset++;
            }

            foreach (var instruction in processor.Body.Instructions.Where(i => i.OpCode == OpCodes.Br_S))
            {
                var distance = instruction.DistanceTo((Instruction)instruction.Operand);
                if (distance < sbyte.MinValue || sbyte.MaxValue < distance)
                {
                    instruction.OpCode = OpCodes.Br;
                }
            }

            foreach (var instruction in processor.Body.Instructions.Where(i => i.OpCode == OpCodes.Brtrue_S))
            {
                var distance = instruction.DistanceTo((Instruction)instruction.Operand);
                if (distance < sbyte.MinValue || sbyte.MaxValue < distance)
                {
                    instruction.OpCode = OpCodes.Brtrue;
                }
            }

            foreach (var instruction in processor.Body.Instructions.Where(i => i.OpCode == OpCodes.Brfalse_S))
            {
                var distance = instruction.DistanceTo((Instruction)instruction.Operand);
                if (distance < sbyte.MinValue || sbyte.MaxValue < distance)
                {
                    instruction.OpCode = OpCodes.Brfalse;
                }
            }
        }

        /// <summary>
        /// IL コードをログ出力します。
        /// </summary>
        /// <param name="method">メソッド定義。</param>
        public static void Log(this MethodDefinition method)
        {
            var processor = method.Body.GetILProcessor();

            Logger.Trace($"{method.FullName}");

            foreach (var instruction in processor.Body.Instructions)
            {
                Logger.Trace($"{instruction}");
            }

            foreach (var handler in processor.Body.ExceptionHandlers)
            {
                Logger.Trace($"TryStart     : {handler.TryStart}");
                Logger.Trace($"TryEnd       : {handler.TryEnd}");
                Logger.Trace($"HandlerStart : {handler.HandlerStart}");
                Logger.Trace($"HandlerEnd   : {handler.HandlerEnd}");
            }
        }

        #endregion
    }
}
