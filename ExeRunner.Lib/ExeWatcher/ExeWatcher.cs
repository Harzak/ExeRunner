using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.ExeWatcher
{
    internal class ExeWatcher : IExeWatcher
    {
        private int _pid;

        internal ExeWatcher(int pid)
        {
            _pid = pid;
        }

        public event EventHandler<ExeWatcherEventArgs> ExeTerminatedAbnormally;

        public void Dispose()
        {
           
        }

        private void stopped()
        {
            ExeTerminatedAbnormally?.Invoke(this, new ExeWatcherEventArgs(_pid));
        }
    }
    internal enum EExeStates
    {
        Starting,
        Started,
        Stopping,
        Stopped,
        Unknow
    }
}
