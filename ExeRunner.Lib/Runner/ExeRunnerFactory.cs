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
        public IExeRunner CreateRunner(string exePath)
        {
            return new ExeRunner(exePath);
        }

        public IExeRunner CreateRunner(ExeLaunchOptions launchOptions, IExeRecoveryPolicy recoveryPolicy = null)
        {
            return new ExeRunner(launchOptions, recoveryPolicy);
        }
    }
}
