using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public interface IExeRecoveryPolicy
    {
        ExeRecoveryAction GetNextRecoveryAction(ExeRecoveryContext context); //failcount is incremented by the main class
    }

    public enum ExeRecoveryAction
    {
        Restart,
        RunOtherProgram,
        NoAction
    }

    public sealed class ExeRecoveryContext
    {
        public int FailCount { get; set; }
        public DateTime Date { get; set; }
        public Exception? Reason { get; set; }
    }
}
