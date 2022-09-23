using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib
{
    internal interface IExeWatcher
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string PID { get; set; }
        public string Path { get; set; }
        public EExeStates State { get; set; }
        public EExeStartupType StartupType { get; set; }
    }

    public enum EExeStates
    {
        Starting,
        Started,
        Stopping,
        Stopped,
        Unknow
    }

    public enum EExeStartupType
    {
        Manual,
        Automatic,
        AutomaticDelayed,
        Disabled
    }
}
