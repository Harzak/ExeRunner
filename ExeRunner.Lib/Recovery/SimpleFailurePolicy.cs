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

        public ExeRecoveryAction GetNextRecoveryAction(ExeRecoveryContext context)
        {
            return context.FailCount < _maxRetry ? ExeRecoveryAction.Restart : ExeRecoveryAction.NoAction;
        }
    }
}
