using ExeRunner.Lib.ExeWatcher;
using ExeRunner.Lib.Recovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Runner
{
    public class ExeRunnerFactory : IExeRunnerFactory
    {
        private readonly IExeWatcherFactory _exeWatcherFactory;
        public ExeRunnerFactory(IExeWatcherFactory exeWatcherFactory)
        {
            _exeWatcherFactory = exeWatcherFactory;
        }

        public IExeRunner CreateRunner(string exePath)
        {
            return new ExeRunner(exePath, _exeWatcherFactory);
        }

        public IExeRunner CreateRunner(ExeLaunchOptions launchOptions, IExeRecoveryPolicy recoveryPolicy = null)
        {
            return new ExeRunner(launchOptions, _exeWatcherFactory, recoveryPolicy);
        }
    }
}
