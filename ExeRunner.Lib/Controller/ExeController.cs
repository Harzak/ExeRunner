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
        private readonly IExeRunnerFactory _runnerFactory;
        private readonly ExeMapping _exeMapping;
        private bool disposedValue;

        public ExeController(IExeRunnerFactory runnerFactory)
        {
            _runnerFactory = runnerFactory;
            _exeMapping = new ExeMapping();
        }

        public Guid RunZenit(List<string> args)
        {
            //get free port and add as argument
            string port = "2568";
            args.Add(port);
            IExeRunner runner = _runnerFactory.CreateRunner(new ExeLaunchOptions()
            {                 
                NoWindow = false,
                Path = @"C:\Workspaces\Sandbox\ConsoleApps_NET_472\TestExeRunner\bin\Debug\net472\TestExeRunner.exe",
            });

            Guid id = Guid.NewGuid();
            if (_exeMapping.TryAdd(id, runner))
            {
                runner.Run(args.ToArray());
                return id;
            } 
            return Guid.Empty;          
        }

        public bool Stop(Guid idExe)
        {
            if (_exeMapping.Any(x => x.Key == idExe))
            {
                IExeRunner runner = _exeMapping[idExe];
                runner.Stop();
                runner.Dispose();
                _exeMapping.TryRemove(idExe, out _);
            }
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _exeMapping?.Dispose();
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
