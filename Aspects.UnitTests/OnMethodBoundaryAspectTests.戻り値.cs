﻿using SoftCube.Log;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using static SoftCube.Aspects.Constants;

namespace SoftCube.Aspects
{
    public partial class OnMethodBoundaryAspectTests
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

        public class 戻り値
        {
            public class @int
            {
                [TestAspect]
                public int p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public int p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public int p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public int p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public int p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public int p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public int p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public int p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public int p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public int p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public int p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [TestAspect]
                public int m1()
                {
                    Logger.Trace("A");
                    return -1;
                }

                [TestAspect]
                public int m2()
                {
                    Logger.Trace("A");
                    return -2;
                }

                [TestAspect]
                public int m3()
                {
                    Logger.Trace("A");
                    return -3;
                }

                [TestAspect]
                public int m4()
                {
                    Logger.Trace("A");
                    return -4;
                }

                [TestAspect]
                public int m5()
                {
                    Logger.Trace("A");
                    return -5;
                }

                [TestAspect]
                public int m6()
                {
                    Logger.Trace("A");
                    return -6;
                }

                [TestAspect]
                public int m7()
                {
                    Logger.Trace("A");
                    return -7;
                }

                [TestAspect]
                public int m8()
                {
                    Logger.Trace("A");
                    return -8;
                }

                [TestAspect]
                public int m9()
                {
                    Logger.Trace("A");
                    return -9;
                }

                [TestAspect]
                public int m10()
                {
                    Logger.Trace("A");
                    return -10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m1();

                        Assert.Equal($"OnEntry A OnSuccess -1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void n2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m2();

                        Assert.Equal($"OnEntry A OnSuccess -2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m3();

                        Assert.Equal($"OnEntry A OnSuccess -3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m4();

                        Assert.Equal($"OnEntry A OnSuccess -4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m5();

                        Assert.Equal($"OnEntry A OnSuccess -5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m6();

                        Assert.Equal($"OnEntry A OnSuccess -6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m7();

                        Assert.Equal($"OnEntry A OnSuccess -7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m8();

                        Assert.Equal($"OnEntry A OnSuccess -8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m9();

                        Assert.Equal($"OnEntry A OnSuccess -9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m10();

                        Assert.Equal($"OnEntry A OnSuccess -10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @short
            {
                [TestAspect]
                public short p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public short p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public short p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public short p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public short p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public short p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public short p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public short p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public short p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public short p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public short p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [TestAspect]
                public short m1()
                {
                    Logger.Trace("A");
                    return -1;
                }

                [TestAspect]
                public short n2()
                {
                    Logger.Trace("A");
                    return -2;
                }

                [TestAspect]
                public short m3()
                {
                    Logger.Trace("A");
                    return -3;
                }

                [TestAspect]
                public short m4()
                {
                    Logger.Trace("A");
                    return -4;
                }

                [TestAspect]
                public short m5()
                {
                    Logger.Trace("A");
                    return -5;
                }

                [TestAspect]
                public short m6()
                {
                    Logger.Trace("A");
                    return -6;
                }

                [TestAspect]
                public short m7()
                {
                    Logger.Trace("A");
                    return -7;
                }

                [TestAspect]
                public short m8()
                {
                    Logger.Trace("A");
                    return -8;
                }

                [TestAspect]
                public short m9()
                {
                    Logger.Trace("A");
                    return -9;
                }

                [TestAspect]
                public short m10()
                {
                    Logger.Trace("A");
                    return -10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m1();

                        Assert.Equal($"OnEntry A OnSuccess -1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void n2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        n2();

                        Assert.Equal($"OnEntry A OnSuccess -2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m3();

                        Assert.Equal($"OnEntry A OnSuccess -3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m4();

                        Assert.Equal($"OnEntry A OnSuccess -4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m5();

                        Assert.Equal($"OnEntry A OnSuccess -5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m6();

                        Assert.Equal($"OnEntry A OnSuccess -6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m7();

                        Assert.Equal($"OnEntry A OnSuccess -7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m8();

                        Assert.Equal($"OnEntry A OnSuccess -8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m9();

                        Assert.Equal($"OnEntry A OnSuccess -9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m10();

                        Assert.Equal($"OnEntry A OnSuccess -10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @long
            {
                [TestAspect]
                public long p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public long p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public long p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public long p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public long p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public long p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public long p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public long p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public long p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public long p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public long p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [TestAspect]
                public long m1()
                {
                    Logger.Trace("A");
                    return -1;
                }

                [TestAspect]
                public long n2()
                {
                    Logger.Trace("A");
                    return -2;
                }

                [TestAspect]
                public long m3()
                {
                    Logger.Trace("A");
                    return -3;
                }

                [TestAspect]
                public long m4()
                {
                    Logger.Trace("A");
                    return -4;
                }

                [TestAspect]
                public long m5()
                {
                    Logger.Trace("A");
                    return -5;
                }

                [TestAspect]
                public long m6()
                {
                    Logger.Trace("A");
                    return -6;
                }

                [TestAspect]
                public long m7()
                {
                    Logger.Trace("A");
                    return -7;
                }

                [TestAspect]
                public long m8()
                {
                    Logger.Trace("A");
                    return -8;
                }

                [TestAspect]
                public long m9()
                {
                    Logger.Trace("A");
                    return -9;
                }

                [TestAspect]
                public long m10()
                {
                    Logger.Trace("A");
                    return -10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m1();

                        Assert.Equal($"OnEntry A OnSuccess -1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void n2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        n2();

                        Assert.Equal($"OnEntry A OnSuccess -2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m3();

                        Assert.Equal($"OnEntry A OnSuccess -3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m4();

                        Assert.Equal($"OnEntry A OnSuccess -4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m5();

                        Assert.Equal($"OnEntry A OnSuccess -5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m6();

                        Assert.Equal($"OnEntry A OnSuccess -6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m7();

                        Assert.Equal($"OnEntry A OnSuccess -7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m8();

                        Assert.Equal($"OnEntry A OnSuccess -8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m9();

                        Assert.Equal($"OnEntry A OnSuccess -9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m10();

                        Assert.Equal($"OnEntry A OnSuccess -10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @uint
            {
                [TestAspect]
                public uint p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public uint p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public uint p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public uint p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public uint p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public uint p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public uint p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public uint p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public uint p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public uint p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public uint p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @ushort
            {
                [TestAspect]
                public ushort p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public ushort p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public ushort p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public ushort p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public ushort p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public ushort p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public ushort p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public ushort p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public ushort p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public ushort p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public ushort p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @ulong
            {
                [TestAspect]
                public ulong p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public ulong p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public ulong p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public ulong p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public ulong p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public ulong p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public ulong p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public ulong p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public ulong p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public ulong p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public ulong p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @byte
            {
                [TestAspect]
                public byte p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public byte p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public byte p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public byte p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public byte p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public byte p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public byte p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public byte p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public byte p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public byte p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public byte p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @sbyte
            {
                [TestAspect]
                public sbyte p0()
                {
                    Logger.Trace("A");
                    return 0;
                }

                [TestAspect]
                public sbyte p1()
                {
                    Logger.Trace("A");
                    return 1;
                }

                [TestAspect]
                public sbyte p2()
                {
                    Logger.Trace("A");
                    return 2;
                }

                [TestAspect]
                public sbyte p3()
                {
                    Logger.Trace("A");
                    return 3;
                }

                [TestAspect]
                public sbyte p4()
                {
                    Logger.Trace("A");
                    return 4;
                }

                [TestAspect]
                public sbyte p5()
                {
                    Logger.Trace("A");
                    return 5;
                }

                [TestAspect]
                public sbyte p6()
                {
                    Logger.Trace("A");
                    return 6;
                }

                [TestAspect]
                public sbyte p7()
                {
                    Logger.Trace("A");
                    return 7;
                }

                [TestAspect]
                public sbyte p8()
                {
                    Logger.Trace("A");
                    return 8;
                }

                [TestAspect]
                public sbyte p9()
                {
                    Logger.Trace("A");
                    return 9;
                }

                [TestAspect]
                public sbyte p10()
                {
                    Logger.Trace("A");
                    return 10;
                }

                [TestAspect]
                public sbyte m1()
                {
                    Logger.Trace("A");
                    return -1;
                }

                [TestAspect]
                public sbyte m2()
                {
                    Logger.Trace("A");
                    return -2;
                }

                [TestAspect]
                public sbyte m3()
                {
                    Logger.Trace("A");
                    return -3;
                }

                [TestAspect]
                public sbyte m4()
                {
                    Logger.Trace("A");
                    return -4;
                }

                [TestAspect]
                public sbyte m5()
                {
                    Logger.Trace("A");
                    return -5;
                }

                [TestAspect]
                public sbyte m6()
                {
                    Logger.Trace("A");
                    return -6;
                }

                [TestAspect]
                public sbyte m7()
                {
                    Logger.Trace("A");
                    return -7;
                }

                [TestAspect]
                public sbyte m8()
                {
                    Logger.Trace("A");
                    return -8;
                }

                [TestAspect]
                public sbyte m9()
                {
                    Logger.Trace("A");
                    return -9;
                }

                [TestAspect]
                public sbyte m10()
                {
                    Logger.Trace("A");
                    return -10;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p2();

                        Assert.Equal($"OnEntry A OnSuccess 2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p3();

                        Assert.Equal($"OnEntry A OnSuccess 3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p4();

                        Assert.Equal($"OnEntry A OnSuccess 4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p5();

                        Assert.Equal($"OnEntry A OnSuccess 5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p6();

                        Assert.Equal($"OnEntry A OnSuccess 6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p7();

                        Assert.Equal($"OnEntry A OnSuccess 7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p8();

                        Assert.Equal($"OnEntry A OnSuccess 8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p9();

                        Assert.Equal($"OnEntry A OnSuccess 9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p10();

                        Assert.Equal($"OnEntry A OnSuccess 10 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m1();

                        Assert.Equal($"OnEntry A OnSuccess -1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void n2_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m2();

                        Assert.Equal($"OnEntry A OnSuccess -2 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m3_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m3();

                        Assert.Equal($"OnEntry A OnSuccess -3 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m4_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m4();

                        Assert.Equal($"OnEntry A OnSuccess -4 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m5_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m5();

                        Assert.Equal($"OnEntry A OnSuccess -5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m6_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m6();

                        Assert.Equal($"OnEntry A OnSuccess -6 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m7_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m7();

                        Assert.Equal($"OnEntry A OnSuccess -7 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m8_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m8();

                        Assert.Equal($"OnEntry A OnSuccess -8 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m9_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m9();

                        Assert.Equal($"OnEntry A OnSuccess -9 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m10_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m10();

                        Assert.Equal($"OnEntry A OnSuccess -10 OnExit ", appender.ToString());
                    }
                }
            }

            public class @bool
            {
                [TestAspect]
                public bool @true()
                {
                    Logger.Trace("A");
                    return true;
                }

                [TestAspect]
                public bool @false()
                {
                    Logger.Trace("A");
                    return false;
                }

                [Fact]
                public void true_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        @true();

                        Assert.Equal($"OnEntry A OnSuccess True OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void false_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        @false();

                        Assert.Equal($"OnEntry A OnSuccess False OnExit ", appender.ToString());
                    }
                }
            }

            public class @double
            {
                [TestAspect]
                public double p0()
                {
                    Logger.Trace("A");
                    return 0.0;
                }

                [TestAspect]
                public double p05()
                {
                    Logger.Trace("A");
                    return 0.5;
                }

                [TestAspect]
                public double p1()
                {
                    Logger.Trace("A");
                    return 1.0;
                }

                [TestAspect]
                public double p100()
                {
                    Logger.Trace("A");
                    return 100.0;
                }

                [TestAspect]
                public double m0()
                {
                    Logger.Trace("A");
                    return -0.0;
                }

                [TestAspect]
                public double m05()
                {
                    Logger.Trace("A");
                    return -0.5;
                }

                [TestAspect]
                public double m1()
                {
                    Logger.Trace("A");
                    return -1.0;
                }

                [TestAspect]
                public double m100()
                {
                    Logger.Trace("A");
                    return -100.0;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p05_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p05();

                        Assert.Equal($"OnEntry A OnSuccess 0.5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p100_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p100();

                        Assert.Equal($"OnEntry A OnSuccess 100 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m05_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m05();

                        Assert.Equal($"OnEntry A OnSuccess -0.5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m1();

                        Assert.Equal($"OnEntry A OnSuccess -1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m100_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m100();

                        Assert.Equal($"OnEntry A OnSuccess -100 OnExit ", appender.ToString());
                    }
                }
            }

            public class @float
            {
                [TestAspect]
                public float p0()
                {
                    Logger.Trace("A");
                    return 0.0f;
                }

                [TestAspect]
                public float p05()
                {
                    Logger.Trace("A");
                    return 0.5f;
                }

                [TestAspect]
                public float p1()
                {
                    Logger.Trace("A");
                    return 1.0f;
                }

                [TestAspect]
                public float p100()
                {
                    Logger.Trace("A");
                    return 100.0f;
                }

                [TestAspect]
                public float m0()
                {
                    Logger.Trace("A");
                    return -0.0f;
                }

                [TestAspect]
                public float m05()
                {
                    Logger.Trace("A");
                    return -0.5f;
                }

                [TestAspect]
                public float m1()
                {
                    Logger.Trace("A");
                    return -1.0f;
                }

                [TestAspect]
                public float m100()
                {
                    Logger.Trace("A");
                    return -100.0f;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p05_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p05();

                        Assert.Equal($"OnEntry A OnSuccess 0.5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p100_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p100();

                        Assert.Equal($"OnEntry A OnSuccess 100 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m0();

                        Assert.Equal($"OnEntry A OnSuccess 0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m05_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m05();

                        Assert.Equal($"OnEntry A OnSuccess -0.5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m1();

                        Assert.Equal($"OnEntry A OnSuccess -1 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m100_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m100();

                        Assert.Equal($"OnEntry A OnSuccess -100 OnExit ", appender.ToString());
                    }
                }
            }

            public class @decimal
            {
                [TestAspect]
                public decimal p0()
                {
                    Logger.Trace("A");
                    return 0.0m;
                }

                [TestAspect]
                public decimal p05()
                {
                    Logger.Trace("A");
                    return 0.5m;
                }

                [TestAspect]
                public decimal p1()
                {
                    Logger.Trace("A");
                    return 1.0m;
                }

                [TestAspect]
                public decimal p100()
                {
                    Logger.Trace("A");
                    return 100.0m;
                }

                [TestAspect]
                public decimal m0()
                {
                    Logger.Trace("A");
                    return -0.0m;
                }

                [TestAspect]
                public decimal m05()
                {
                    Logger.Trace("A");
                    return -0.5m;
                }

                [TestAspect]
                public decimal m1()
                {
                    Logger.Trace("A");
                    return -1.0m;
                }

                [TestAspect]
                public decimal m100()
                {
                    Logger.Trace("A");
                    return -100.0m;
                }

                [Fact]
                public void p0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p0();

                        Assert.Equal($"OnEntry A OnSuccess 0.0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p05_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p05();

                        Assert.Equal($"OnEntry A OnSuccess 0.5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p1();

                        Assert.Equal($"OnEntry A OnSuccess 1.0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void p100_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        p100();

                        Assert.Equal($"OnEntry A OnSuccess 100.0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m0_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m0();

                        Assert.Equal($"OnEntry A OnSuccess 0.0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m05_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m05();

                        Assert.Equal($"OnEntry A OnSuccess -0.5 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m1_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m1();

                        Assert.Equal($"OnEntry A OnSuccess -1.0 OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void m100_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        m100();

                        Assert.Equal($"OnEntry A OnSuccess -100.0 OnExit ", appender.ToString());
                    }
                }
            }

            public class @char
            {
                [TestAspect]
                public char a()
                {
                    Logger.Trace("A");
                    return 'a';
                }

                [TestAspect]
                public char あ()
                {
                    Logger.Trace("A");
                    return 'あ';
                }

                [Fact]
                public void a_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        a();

                        Assert.Equal($"OnEntry A OnSuccess a OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void あ_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        あ();

                        Assert.Equal($"OnEntry A OnSuccess あ OnExit ", appender.ToString());
                    }
                }
            }

            public class @string
            {
                [TestAspect]
                public string a()
                {
                    Logger.Trace("A");
                    return "a";
                }

                [TestAspect]
                public string あ()
                {
                    Logger.Trace("A");
                    return "あ";
                }

                [Fact]
                public void a_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        a();

                        Assert.Equal($"OnEntry A OnSuccess a OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void あ_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        あ();

                        Assert.Equal($"OnEntry A OnSuccess あ OnExit ", appender.ToString());
                    }
                }
            }

            public class @class
            {
                public class Class
                {
                    public string Property { get; set; }

                    public override string ToString() => Property;
                }

                [TestAspect]
                public Class a()
                {
                    Logger.Trace("A");
                    return new Class() { Property = "a" };
                }

                [Fact]
                public void a_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        a();

                        Assert.Equal($"OnEntry A OnSuccess a OnExit ", appender.ToString());
                    }
                }
            }

            public class @struct
            {
                public struct Struct
                {
                    public string Property { get; set; }

                    public override string ToString() => Property;
                }

                [TestAspect]
                public Struct a()
                {
                    Logger.Trace("A");
                    return new Struct() { Property = "a" };
                }

                [Fact]
                public void a_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        a();

                        Assert.Equal($"OnEntry A OnSuccess a OnExit ", appender.ToString());
                    }
                }
            }

            public class Collection
            {
                [TestAspect]
                public IEnumerable IEnumerable()
                {
                    Logger.Trace("A");

                    var result = new List<int>();
                    result.Add(0);
                    return result;
                }

                [TestAspect]
                public IEnumerable<int> IEnumerableT()
                {
                    Logger.Trace("A");

                    var result = new List<int>();
                    result.Add(0);
                    return result;
                }

                [TestAspect]
                public List<int> ListT()
                {
                    Logger.Trace("A");

                    var result = new List<int>();
                    result.Add(0);
                    return result;
                }

                [TestAspect]
                public IEnumerable<int> 遅延評価()
                {
                    Logger.Trace("A");

                    yield return 0;
                    yield return 1;
                }

                [Fact]
                public void IEnumerable_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        IEnumerable();

                        Assert.Equal($"OnEntry A OnSuccess [0] OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void IEnumerableT_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        IEnumerableT();

                        Assert.Equal($"OnEntry A OnSuccess [0] OnExit ", appender.ToString());
                    }
                }

                [Fact]
                public void ListT_成功する()
                {
                    lock (Lock)
                    {
                        var appender = CreateAppender();

                        ListT();

                        Assert.Equal($"OnEntry A OnSuccess [0] OnExit ", appender.ToString());
                    }
                }

                //[Fact]
                //public void 遅延評価_成功する()
                //{
                //    lock (Lock)
                //    {
                //        var appender = InitializeLogger();

                //        foreach (var item in 遅延評価())
                //        {
                //        }

                //        Assert.Equal($"OnEntry A OnSuccess [0] OnExit ", appender.ToString());
                //    }
                //}
            }
        }
    }
}
