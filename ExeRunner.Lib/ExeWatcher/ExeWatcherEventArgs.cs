using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.ExeWatcher
{
    public class ExeWatcherEventArgs : EventArgs
    {
        public int PID { get; set; }

        public ExeWatcherEventArgs(int pID)
        {
            PID = pID;    
        }
    }
}
