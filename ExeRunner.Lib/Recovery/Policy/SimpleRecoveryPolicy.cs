using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public sealed class SimpleRecoveryPolicy : IExeRecoveryPolicy
    {
        private int _maxRetry;

        public SimpleRecoveryPolicy(int maxRetry)
        {
            _maxRetry = maxRetry;   
        }

        public RecoveryStrategieModel GetRecoveryStrategy(ExeRecoveryContext context)
        {
            EExeRecoveryAction action = context.FailCount < _maxRetry ? EExeRecoveryAction.Restart : EExeRecoveryAction.NoAction;
            return new RecoveryStrategieModel(_maxRetry, TimeSpan.FromMilliseconds(1), action);
        }
    }
}
