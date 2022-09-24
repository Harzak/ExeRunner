using ExeRunner.Lib.Recovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib
{
    public class ExeController : IExeRunner
    {
        private readonly IExeRecoveryPolicy _recoveryPolicy;
        private readonly string _path;
        private EExeStartupType _startupType;

        public EExeStartupType StartupType
        {
            get => _startupType;
            set => _startupType = value; 
        }

        public ExeController(string exePath) 
        {
            _path = exePath;
            _recoveryPolicy = new SimpleFailurePolicy(0);
        }

        public ExeController(string exePath, IExeRecoveryPolicy recoveryPolicy)
        {
            _path = exePath;  
            _recoveryPolicy = recoveryPolicy;
            _startupType = EExeStartupType.Automatic;
        }

        public bool Run(string[] args)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RunAsync(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }
    }
}
