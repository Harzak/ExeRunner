using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public class RecoveryStrategieModel
    {
        public int MaxRetry { get; set; }
        public TimeSpan Delay { get; set; }
        public EExeRecoveryAction Action { get; set; }

        public RecoveryStrategieModel(int maxRetry, TimeSpan delay, EExeRecoveryAction action)
        {
            MaxRetry = maxRetry;
            Delay = delay;
            Action=action;      
        }
    }
}
