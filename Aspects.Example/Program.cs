﻿using SoftCube.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoftCube.Aspects
{
    /// <summary>
    /// プログラム。
    /// </summary>
    class Program
    {
        /// <summary>
        /// メイン関数。
        /// </summary>
        /// <param name="args">アプリケーション引数。</param>
        static void Main(string[] args)
        {
            var program = new Program();
            program.Test("A", "B");

            Logger.Trace("C");

            Console.Read();



            ////var type = typeof(OnMethodBoundaryAspectTests.引数と戻り値.Class).FullName;

            ////new Program().Test(true);
            ////Logger.Trace(result.ToString());

            //new Program().引数が1つ("a");
            ////var result = new Program().IEnumerableInt(0, 1, 2);

            ////foreach (var item in result)
            ////{
            ////    Logger.Trace(item.ToString());
            ////}

            //Console.Read();
        }

        [OnMethodBoundaryAspectLogger]
        private async Task<string> Test(string value1, string value2)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                Logger.Trace(value1);
            });

            await Task.Run(() =>
            {
                Thread.Sleep(100);
                Logger.Trace(value2);
            });

            return value2;
        }

        //[OnMethodBoundaryAspectLogger]
        //private async Task Test(string value1, string value2)
        //{
        //    await Task.Run(() =>
        //    {
        //        Thread.Sleep(100);
        //        Logger.Trace(value1);
        //    });

        //    await Task.Run(() =>
        //    {
        //        Thread.Sleep(100);
        //        Logger.Trace(value2);
        //    });
        //}



        //[OnMethodBoundaryAspectLogger]
        //private IEnumerable<string> 引数が1つ(string value0)
        //{
        //    yield return value0;
        //}

        //[OnMethodBoundaryAspectLogger]
        //private IEnumerable<int> IEnumerableInt(int a0, int value1, int value2)
        //{
        //    Logger.Trace("a");
        //    yield return a0;
        //    Logger.Trace("b");
        //    yield return value1;
        //    Logger.Trace("c");
        //    yield return value2;
        //    Logger.Trace("d");
        //}

        //[OnMethodBoundaryAspectLogger]
        //private void Test(bool condition)
        //{
        //    if (condition)
        //    {
        //        Logger.Trace("A");
        //        return;
        //    }

        //    Logger.Trace("B");
        //}
        //[OnMethodBoundaryAspectLogger]
        //private bool Test(bool condition)
        //{
        //    if (condition)
        //    {
        //        Logger.Trace("A");
        //        return true;
        //    }
        //    else
        //    {
        //        Logger.Trace("B");
        //        return false;
        //    }
        //}
        //[OnMethodBoundaryAspectLogger]
        //private int Test(string value)
        //{
        //    Logger.Trace("1");
        //    Logger.Trace("2");
        //    Logger.Trace("3");
        //    return int.Parse(value);
        //}
    }
}


namespace SoftCube.Aspects
{
    public partial class OnMethodBoundaryAspectTests
    {
        public class 引数と戻り値
        {
            public class Class
            {
                public string Property { get; set; }

                public override string ToString() => Property;
            }
        }
    }
}


