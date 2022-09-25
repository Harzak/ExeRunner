using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public class DelayRecoveryPolicy : IExeRecoveryPolicy
    {
        private readonly Dictionary<int, TimeSpan> _tempoRetry;

        public DelayRecoveryPolicy()
        {
            _tempoRetry = new Dictionary<int, TimeSpan>()
            {
                { 20, TimeSpan.FromSeconds(3) },
                { 60, TimeSpan.FromSeconds(6) },
                { 180, TimeSpan.FromSeconds(30) },
                { 540, TimeSpan.FromMinutes(2) },
            };
        }

        public RecoveryStrategieModel GetRecoveryStrategy(ExeRecoveryContext context)
        {
            TimeSpan delay = _tempoRetry.First(x => context.FailCount <= x.Key).Value;
            return new RecoveryStrategieModel(540, delay, EExeRecoveryAction.Restart);
        }
    }
}
