using ExeRunner.Lib.ExeWatcher;
using ExeRunner.Lib.Runner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Controller
{
    public class ExeController : IDisposable
    {
        protected IExeRunnerFactory RunnerFactory { get; }
        private readonly RunnerCollection _runners;
        private bool disposedValue;

        public ExeController(IExeRunnerFactory runnerFactory)
        {
            RunnerFactory = runnerFactory;
            _runners = new RunnerCollection();
        }

        public Guid Register(ExeLaunchOptions launchOptions)
        {
            IExeRunner runner = RunnerFactory.CreateRunner(launchOptions);
            _runners.Add(runner);
            return runner.Id;
        }

        public bool Run(Guid idExe, string[] args)
        {
            if (_runners.Any(x => x.Id == idExe))
            {
               return _runners.First(x => x.Id == idExe)
                        .Run(args);
            }
            return false;
        }

        public bool Stop(Guid idExe)
        {
            if (_runners.Any(x => x.Id == idExe))
            {
                IExeRunner runner = _runners.First(x => x.Id == idExe);
                runner.Stop();
                runner.Dispose();
                _runners.TryTake(out runner);
            }
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _runners?.Dispose();
                }
                disposedValue=true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
