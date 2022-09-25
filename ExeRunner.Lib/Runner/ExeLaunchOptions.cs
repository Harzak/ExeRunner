using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Runner
{
    public class ExeLaunchOptions
    {
        public string Path { get; set; }
        public bool NoWindow { get; set; }
    }
}
