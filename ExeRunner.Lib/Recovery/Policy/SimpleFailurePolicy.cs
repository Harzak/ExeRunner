using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public sealed class SimpleFailurePolicy : IExeRecoveryPolicy
    {
        private int _maxRetry;

        public SimpleFailurePolicy(int maxRetry)
        {
            _maxRetry = maxRetry;   
        }

        public RecoveryPolicyModel GetNextRecoveryAction(ExeRecoveryContext context)
        {
            EExeRecoveryAction action = context.FailCount < _maxRetry ? EExeRecoveryAction.Restart : EExeRecoveryAction.NoAction;
            return new RecoveryPolicyModel(_maxRetry, TimeSpan.FromMilliseconds(1), action);
        }
    }
}
