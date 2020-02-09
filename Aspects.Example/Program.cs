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
            var result = program.Test("A");

            //foreach (var value in result)
            //{
            //    Logger.Trace(value);
            //}

            Logger.Trace("C");

            Console.Read();
        }

        [OnMethodBoundaryAspectLogger]
        private string Test(string value)
        {
            return value;
        }



        //[OnMethodBoundaryAspectLogger]
        //private async Task<string> Test(string value1, string value2)
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

        //    return value2;
        //}

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


    }
}
