using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExeRunner.Lib.ExeWatcher
{
    public interface IExeWatcher : IDisposable
    {
        Task StartAsync(CancellationToken cancellationToken);
             
       event EventHandler<ExeWatcherEventArgs> ExeTerminatedAbnormally;
    }
}
