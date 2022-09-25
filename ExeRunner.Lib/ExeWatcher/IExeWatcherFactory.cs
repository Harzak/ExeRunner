using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.ExeWatcher
{
    public interface IExeWatcherFactory
    {
        IExeWatcher CreateExeWatcher(int pid);
    }
}
