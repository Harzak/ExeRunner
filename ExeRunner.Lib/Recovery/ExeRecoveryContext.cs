using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public sealed class ExeRecoveryContext
    {
        public int FailCount { get; set; }
        public DateTime Date { get; set; }
        public Exception Reason { get; set; }
    }
}
