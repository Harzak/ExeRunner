using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public interface IExeRecoveryPolicy
    {
        RecoveryPolicyModel GetNextRecoveryAction(ExeRecoveryContext context); //failcount is incremented by the main class
    }
}
