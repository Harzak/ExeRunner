using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExeRunner.Lib.ExeWatcher
{
    internal class ExeWatcher : IExeWatcher
    {
        private int _pid;

        internal ExeWatcher(int pid)
        {
            _pid = pid;       
        }

        public event EventHandler<ExeWatcherEventArgs> ExeTerminatedAbnormally;

        public void Dispose()
        {

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                string a = $"TargetInstance isa \"Win32_Process\" and TargetInstance.Name = 'TestExeRunner'";
                string b = $"TargetInstance isa \"Win32_ProcessStopTrace\" and TargetInstance.Name = 'TestExeRunner'";
                WqlEventQuery query = new WqlEventQuery($"SELECT * FROM Win32_ProcessStopTrace WHERE Name = 'TestExeRunner' ");

                ManagementEventWatcher watcher = new ManagementEventWatcher();
                watcher.Query = query;
                ManagementBaseObject e = watcher.WaitForNextEvent();
                //Display information from the event
                Console.WriteLine("YOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");

                watcher.EventArrived += Watcher_EventArrived;



            }
            catch (Exception ex)
            {
                var eee = 1;
            }
            return  Task.CompletedTask;
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var eee = 222;
        }

        private void stopped()
        {
            ExeTerminatedAbnormally?.Invoke(this, new ExeWatcherEventArgs(_pid));
        }
    }
    internal enum EExeStates
    {
        Starting,
        Started,
        Stopping,
        Stopped,
        Unknow
    }
}
