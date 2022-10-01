using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.ExeWatcher
{
    public class ExeWatcherFactory : IExeWatcherFactory
    {
        public IExeWatcher CreateExeWatcher(int pid)
        {
            return new ExeWatcher(pid);
        }
    }
}
