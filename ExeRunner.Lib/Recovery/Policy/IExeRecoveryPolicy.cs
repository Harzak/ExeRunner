using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Recovery
{
    public interface IExeRecoveryPolicy
    {
        RecoveryStrategieModel GetRecoveryStrategy(ExeRecoveryContext context); //failcount is incremented by the main class
    }
}
