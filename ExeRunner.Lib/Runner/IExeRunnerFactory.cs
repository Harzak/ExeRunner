using ExeRunner.Lib.Recovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Runner
{
    public interface IExeRunnerFactory
    {
        IExeRunner CreateRunner(string exePath);
        IExeRunner CreateRunner(ExeLaunchOptions launchOptions, IExeRecoveryPolicy recoveryPolicy = null);
    }
}
