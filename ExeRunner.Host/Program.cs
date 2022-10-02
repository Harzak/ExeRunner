using ExeRunner.Lib;
using ExeRunner.Lib.ExeWatcher;
using ExeRunner.Lib.Runner;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ExeRunner
{
    internal class Program
    {

        static void Main(string[] args)
        {

            using (var controller = new Lib.Controller.ZenitExeController(new ExeRunnerFactory(new ExeWatcherFactory())))
            {
                Console.WriteLine("Start");
                controller.RunZenitExe(new List<string> { "test", "111", "test2", "22" });
                //Console.WriteLine("Sleep");

                //Console.WriteLine("try to stop");
                //controller.StopZenitExe();
                //Console.WriteLine("Stopped");

            }
            
            Console.ReadKey();
        }
    }
}