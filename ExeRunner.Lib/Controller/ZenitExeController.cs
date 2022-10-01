using ExeRunner.Lib.Runner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Controller
{
    public class ZenitExeController : ExeController
    {
        private Guid _zenitRunnerId;
        public ZenitExeController(IExeRunnerFactory runnerFactory) : base(runnerFactory)
        {
            _zenitRunnerId = Guid.Empty;
        }

        public bool RunZenitExe(List<string> args)
        {
            _zenitRunnerId = Register(new ExeLaunchOptions()
            {
                NoWindow = false,
                Path = @"C:\Workspaces\Sandbox\ConsoleApps_NET_472\TestExeRunner\bin\Debug\net472\TestExeRunner.exe",
            });

            //get free port and add as argument
            string port = "2568";
            args.Add(port);

            return Run(_zenitRunnerId, args.ToArray());
        }

        public bool StopZenitExe()
        {
            return base.Stop(_zenitRunnerId);
        }

    }
}
