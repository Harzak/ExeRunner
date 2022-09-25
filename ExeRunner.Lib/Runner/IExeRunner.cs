using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Runner
{
    public interface IExeRunner : IDisposable
    {
        int PID { get; }

        bool Run(string[] args);
        Task<bool> RunAsync(string[] args, CancellationToken cancellation);
        bool Stop();
        Task<bool> StopAsync(CancellationToken cancellation);
    }
}
