﻿using SoftCube.Logging;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using static SoftCube.Aspects.Constants;

namespace SoftCube.Aspects
{
    public class MethodInterceptionAspectTests
    {
        #region テストユーティリティ

        internal static StringAppender CreateAppender()
        {
            var appender = new StringAppender();
            appender.LogFormat = "{Message} ";
            Logger.Add(appender);

            return appender;
        }

        #endregion

        public class 引数と戻り値
        {
            #region 引数と戻り値なし

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private void 引数と戻り値なし_Invoke()
            {
                Logger.Trace("A");
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private void 引数と戻り値なし_Proceed()
            {
                Logger.Trace("A");
            }

            [Fact]
            public void 引数と戻り値なし_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    引数と戻り値なし_Invoke();

                    Assert.Equal($"OnInvoke Invoke A null ", appender.ToString());
                }
            }

            [Fact]
            public void 引数と戻り値なし_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    引数と戻り値なし_Proceed();

                    Assert.Equal($"OnInvoke Proceed A null ", appender.ToString());
                }
            }

            #endregion

            #region 引数のみ

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private void 引数のみ_Invoke(int value)
            {
                Logger.Trace("A");
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private void 引数のみ_Proceed(int value)
            {
                Logger.Trace("A");
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void 引数のみ_Invoke_成功する(int value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    引数のみ_Invoke(value);

                    Assert.Equal($"OnInvoke {value} Invoke A null ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void 引数のみ_Proceed_成功する(int value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    引数のみ_Proceed(value);

                    Assert.Equal($"OnInvoke {value} Proceed A null ", appender.ToString());
                }
            }

            #endregion

            #region 複数の引数

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private void 複数の引数_Invoke(int value, string @string)
            {
                Logger.Trace("A");
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private void 複数の引数_Proceed(int value, string @string)
            {
                Logger.Trace("A");
            }

            [Fact]
            public void 複数の引数_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    複数の引数_Invoke(7, "あ");

                    Assert.Equal($"OnInvoke 7 \"あ\" Invoke A null ", appender.ToString());
                }
            }

            [Fact]
            public void 複数の引数_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    複数の引数_Proceed(7, "あ");

                    Assert.Equal($"OnInvoke 7 \"あ\" Proceed A null ", appender.ToString());
                }
            }

            #endregion

            #region 戻り値のみ

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private int 戻り値のみ_Invoke()
            {
                Logger.Trace("A");
                return 7;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private int 戻り値のみ_Proceed()
            {
                Logger.Trace("A");
                return 7;
            }

            [Fact]
            public void 戻り値のみ_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = 戻り値のみ_Invoke();

                    Assert.Equal(7, result);
                    Assert.Equal($"OnInvoke Invoke A {result} ", appender.ToString());
                }
            }

            [Fact]
            public void 戻り値のみ_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = 戻り値のみ_Proceed();

                    Assert.Equal(7, result);
                    Assert.Equal($"OnInvoke Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region さまざまな型の引数と戻り値

            #region int

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private int int_Invoke(int value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private int int_Proceed(int value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void int_Invoke_成功する(int value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = int_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void int_Proceed_成功する(int value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = int_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region short

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private short short_Invoke(short value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private short short_Proceed(short value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void short_Invoke_成功する(short value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = short_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {value} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void short_Proceed_成功する(short value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = short_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region sbyte

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private sbyte sbyte_Invoke(sbyte value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private sbyte sbyte_Proceed(sbyte value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void sbyte_Invoke_成功する(sbyte value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = sbyte_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void sbyte_Proceed_成功する(sbyte value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = sbyte_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region long

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private long long_Invoke(long value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private long long_Proceed(long value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void long_Invoke_成功する(long value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = long_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {value} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            [InlineData(-1)]
            [InlineData(-2)]
            [InlineData(-3)]
            [InlineData(-4)]
            [InlineData(-5)]
            [InlineData(-6)]
            [InlineData(-7)]
            [InlineData(-8)]
            [InlineData(-10)]
            public void long_Proceed_成功する(long value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = long_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region uint

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private uint uint_Invoke(uint value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private uint uint_Proceed(uint value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void uint_Invoke_成功する(uint value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = uint_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void uint_Proceed_成功する(uint value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = uint_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region ushort

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private ushort ushort_Invoke(ushort value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private ushort ushort_Proceed(ushort value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void ushort_Invoke_成功する(ushort value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = ushort_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void ushort_Proceed_成功する(ushort value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = ushort_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region ulong

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private ulong ulong_Invoke(ulong value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private ulong ulong_Proceed(ulong value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void ulong_Invoke_成功する(ulong value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = ulong_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void ulong_Proceed_成功する(ulong value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = ulong_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region byte

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private byte byte_Invoke(byte value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private byte byte_Proceed(byte value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void byte_Invoke_成功する(byte value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = byte_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(10)]
            public void byte_Proceed_成功する(byte value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = byte_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region bool

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private bool bool_Invoke(bool value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private bool bool_Proceed(bool value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(false)]
            [InlineData(true)]
            public void bool_Invoke_成功する(bool value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = bool_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(false)]
            [InlineData(true)]
            public void bool_Proceed_成功する(bool value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = bool_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region double

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private double double_Invoke(double value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private double double_Proceed(double value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0.0)]
            [InlineData(0.5)]
            [InlineData(1.0)]
            [InlineData(100.0)]
            [InlineData(-0.5)]
            [InlineData(-1.0)]
            [InlineData(-100.0)]
            public void double_Invoke_成功する(double value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = double_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0.0)]
            [InlineData(0.5)]
            [InlineData(1.0)]
            [InlineData(100.0)]
            [InlineData(-0.5)]
            [InlineData(-1.0)]
            [InlineData(-100.0)]
            public void double_Proceed_成功する(double value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = double_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region float

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private float float_Invoke(float value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private float float_Proceed(float value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0.0)]
            [InlineData(0.5)]
            [InlineData(1.0)]
            [InlineData(100.0)]
            [InlineData(-0.5)]
            [InlineData(-1.0)]
            [InlineData(-100.0)]
            public void float_Invoke_成功する(float value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = float_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0.0)]
            [InlineData(0.5)]
            [InlineData(1.0)]
            [InlineData(100.0)]
            [InlineData(-0.5)]
            [InlineData(-1.0)]
            [InlineData(-100.0)]
            public void float_Proceed_成功する(float value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = float_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region decimal

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private decimal decimal_Invoke(decimal value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private decimal decimal_Proceed(decimal value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData(0.0)]
            [InlineData(0.5)]
            [InlineData(1.0)]
            [InlineData(100.0)]
            [InlineData(-0.5)]
            [InlineData(-1.0)]
            [InlineData(-100.0)]
            public void decimal_Invoke_成功する(decimal value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = decimal_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Theory]
            [InlineData(0.0)]
            [InlineData(0.5)]
            [InlineData(1.0)]
            [InlineData(100.0)]
            [InlineData(-0.5)]
            [InlineData(-1.0)]
            [InlineData(-100.0)]
            public void decimal_Proceed_成功する(decimal value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = decimal_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region char

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private char char_Invoke(char value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private char char_Proceed(char value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData('a')]
            [InlineData('あ')]
            public void char_Invoke_成功する(char value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = char_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke '{value}' Invoke A '{result}' ", appender.ToString());
                }
            }

            [Theory]
            [InlineData('a')]
            [InlineData('あ')]
            public void char_Proceed_成功する(char value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = char_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke '{value}' Proceed A '{result}' ", appender.ToString());
                }
            }

            #endregion

            #region string

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private string string_Invoke(string value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private string string_Proceed(string value)
            {
                Logger.Trace("A");
                return value;
            }

            [Theory]
            [InlineData("a")]
            [InlineData("あ")]
            public void string_Invoke_成功する(string value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = string_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke \"{value}\" Invoke A \"{result}\" ", appender.ToString());
                }
            }

            [Theory]
            [InlineData("a")]
            [InlineData("あ")]
            public void string_Proceed_成功する(string value)
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();

                    var result = string_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke \"{value}\" Proceed A \"{result}\" ", appender.ToString());
                }
            }

            #endregion

            #region class

            public class Class
            {
                public string Property { get; set; }

                public override string ToString() => Property;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private Class class_Invoke(Class value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private Class class_Proceed(Class value)
            {
                Logger.Trace("A");
                return value;
            }

            [Fact]
            public void class_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new Class() { Property = "a" };

                    var result = class_Invoke(value);

                    Assert.Same(value, result);
                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Fact]
            public void class_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new Class() { Property = "a" };

                    var result = class_Proceed(value);

                    Assert.Same(value, result);
                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region struct

            public struct Struct
            {
                public string Property { get; set; }

                public override string ToString() => Property;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private Struct struct_Invoke(Struct value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private Struct struct_Proceed(Struct value)
            {
                Logger.Trace("A");
                return value;
            }

            [Fact]
            public void struct_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new Struct() { Property = "a" };

                    var result = struct_Invoke(value);

                    Assert.Equal($"OnInvoke {value} Invoke A {result} ", appender.ToString());
                }
            }

            [Fact]
            public void struct_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new Struct() { Property = "a" };

                    var result = struct_Proceed(value);

                    Assert.Equal($"OnInvoke {value} Proceed A {result} ", appender.ToString());
                }
            }

            #endregion

            #region Collection

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private IEnumerable IEnumerable_Invoke(IEnumerable value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private IEnumerable IEnumerable_Proceed(IEnumerable value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private IEnumerable<int> IEnumerableT_Invoke(IEnumerable<int> value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private IEnumerable<int> IEnumerableT_Proceed(IEnumerable<int> value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Invoke)]
            private List<int> ListT_Invoke(List<int> value)
            {
                Logger.Trace("A");
                return value;
            }

            [MethodInterceptionAspectLogger(MethodInterceptionType.Proceed)]
            private List<int> ListT_Proceed(List<int> value)
            {
                Logger.Trace("A");
                return value;
            }

            [Fact]
            public void IEnumerable_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value    = new List<int>() { 0 };

                    var result = IEnumerable_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke [0] Invoke A [0] ", appender.ToString());
                }
            }

            [Fact]
            public void IEnumerable_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value    = new List<int>() { 0 };

                    var result = IEnumerable_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke [0] Proceed A [0] ", appender.ToString());
                }
            }

            [Fact]
            public void IEnumerableT_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new List<int>() { 0 };

                    var result = IEnumerableT_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke [0] Invoke A [0] ", appender.ToString());
                }
            }

            [Fact]
            public void IEnumerableT_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new List<int>() { 0 };

                    var result = IEnumerableT_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke [0] Proceed A [0] ", appender.ToString());
                }
            }

            [Fact]
            public void ListT_Invoke_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new List<int>() { 0 };

                    var result = ListT_Invoke(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke [0] Invoke A [0] ", appender.ToString());
                }
            }

            [Fact]
            public void ListT_Proceed_成功する()
            {
                lock (LockObject)
                {
                    var appender = CreateAppender();
                    var value = new List<int>() { 0 };

                    var result = ListT_Proceed(value);

                    Assert.Equal(value, result);
                    Assert.Equal($"OnInvoke [0] Proceed A [0] ", appender.ToString());
                }
            }

            #endregion

            #endregion
        }
    }
}
