using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib
{
    internal interface IExeRunner
    {
        public bool Run(string[] args); 
        public Task<bool> RunAsync(string[] args);
        public bool Stop();
    }
}
