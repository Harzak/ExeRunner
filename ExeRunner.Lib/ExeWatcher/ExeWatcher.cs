using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.ExeWatcher
{
    public class ExeWatcher : IExeWatcher
    {
        private int _pid;

        public ExeWatcher(int pid)
        {
            _pid = pid;
        }

        public event EventHandler<ExeWatcherEventArgs> ExeTerminatedAbnormally;

        private void stopped()
        {
            ExeTerminatedAbnormally?.Invoke(this, new ExeWatcherEventArgs(_pid));
        }
    }
    public enum EExeStates
    {
        Starting,
        Started,
        Stopping,
        Stopped,
        Unknow
    }
}
