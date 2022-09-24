using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public class DelayRetryPolicy : IExeRecoveryPolicy
    {
        private readonly Dictionary<int, TimeSpan> _tempoRetry;

        public DelayRetryPolicy()
        {
            _tempoRetry = new Dictionary<int, TimeSpan>()
            {
                { 20, TimeSpan.FromSeconds(3) },
                { 60, TimeSpan.FromSeconds(6) },
                { 180, TimeSpan.FromSeconds(30) },
                { 540, TimeSpan.FromMinutes(2) },
            };
        }

        public RecoveryPolicyModel GetNextRecoveryAction(ExeRecoveryContext context)
        {
            TimeSpan delay = _tempoRetry.First(x => context.FailCount<= x.Key).Value;
            return new RecoveryPolicyModel(540, delay, EExeRecoveryAction.Restart);
        }
    }
}
