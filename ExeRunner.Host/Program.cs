using ExeRunner.Lib;
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

            using (var controller = new Lib.Controller.ExeController(new ExeRunnerFactory()))
            {
                Console.WriteLine("Start");
                Guid id= controller.RunZenit(new List<string> {"test","111", "test2", "22"});
                Console.WriteLine("Sleep");
                Thread.Sleep(6000);
                Console.WriteLine("try to stop");
                controller.Stop(id);
                Console.WriteLine("Stopped");
            }
            
            Console.ReadKey();
        }
    }
}