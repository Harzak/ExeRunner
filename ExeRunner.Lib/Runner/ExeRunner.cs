using ExeRunner.Lib.ExeWatcher;
using ExeRunner.Lib.Recovery;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Runner
{
    public class ExeRunner : IExeRunner, IDisposable
    {
        private bool disposedValue;
        private readonly IExeRecoveryPolicy _recoveryPolicy;
        private readonly IExeWatcherFactory _watcherFactory;
        private readonly string _path;
        private readonly bool _noWindow;
        private readonly int _failCount;
        private readonly Guid _id;

        private int _tryRunCount;
        private string[] _args;
        private Func<bool> _batchStopProcess;
        private IExeWatcher _watcher;

        private Process _process;

        public int PID
        {
            get => _process?.Id ?? -1;
        }

        public Guid Id
        {
            get => _id;
        }

        public ExeRunner(string exePath, IExeWatcherFactory watcherFactory)
        {
            _path = exePath;
            _id = Guid.NewGuid();
            _watcherFactory = watcherFactory;
            _noWindow = false;
            _recoveryPolicy = new SimpleRecoveryPolicy(0);
        }

        public ExeRunner(ExeLaunchOptions launchOptions, IExeWatcherFactory watcherFactory, IExeRecoveryPolicy recoveryPolicy = null)
        {
            if (launchOptions == null)
            {
                throw new ArgumentNullException(nameof(launchOptions));
            }

            _watcherFactory = watcherFactory;
            _path = launchOptions.Path;
            _noWindow = launchOptions.NoWindow;
            _recoveryPolicy = recoveryPolicy ?? new SimpleRecoveryPolicy(0);
        }

        public Task<bool> RunAsync(string[] args, CancellationToken cancellation)
        {
            return Task.Run(() => Run(args), cancellation);
        }

        public bool Run(string[] args)
        {
            _args = args;
            return RunInternal(TimeSpan.FromMilliseconds(1));
        }

        private bool RunInternal(TimeSpan wait)
        {
            Thread.Sleep(wait);
            bool failed = false;
            _tryRunCount++;

            _process = new Process()
            {
                EnableRaisingEvents = true
            };
            _process.StartInfo.FileName = _path;
            _process.StartInfo.CreateNoWindow = _noWindow;
            _process.StartInfo.UseShellExecute = !_noWindow;

            if (_args != null && _args.Any())
            {
                _process.StartInfo.Arguments = string.Join(" ", _args);
            }

            try
            {
                _process.Start();
                _process.EnableRaisingEvents = true;
                _process.Exited += OnProcessExited;
            }
            catch (Exception ex)
            {
                failed = true;
            }

            if (failed && _tryRunCount < 10)
            {
                RunInternal(TimeSpan.FromSeconds(20));
            }
            else if (failed)
            {
                return false;
            }

            _process.Exited +=_process_Exited;
            _watcher = _watcherFactory.CreateExeWatcher(PID);
            _watcher.StartAsync(cancellationToken: default);
            _watcher.ExeTerminatedAbnormally += OnProcessTerminatedAbnormally;
            return true;
        }

        private void _process_Exited(object sender, EventArgs e)
        {
            var ee = 11;
        }

        public Task<bool> StopAsync(CancellationToken cancellation)
        {
            return Task.Run(() => Stop(), cancellation);
        }

        public bool Stop()
        {
            bool success = false;
            try
            {
                if (_batchStopProcess != null)
                {
                    success = _batchStopProcess.Invoke();
                }
            }
            catch (Exception)
            {

            }

            if (!success)
            {
                return ForceStop();
            }

            return success;
        }

        private bool ForceStop()
        {
            try
            {
                _process.Kill();
                _process.WaitForExit();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public ExeRunner ExecuteOnStop(Func<bool> action)
        {
            _batchStopProcess = action;
            return this;
        }

        private bool Recover()
        {
            RecoveryStrategieModel recoveryStrategy = _recoveryPolicy.GetRecoveryStrategy(new ExeRecoveryContext()
            {
                Date = DateTime.Now,
                FailCount = _failCount,
            });

            switch (recoveryStrategy.Action)
            {
                case EExeRecoveryAction.Restart:
                    return RunInternal(recoveryStrategy.Delay);
                default:
                    break;
            }

            return true;
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            _process?.Close();
            _process?.Dispose();
        }

        private void OnProcessTerminatedAbnormally(object sender, ExeWatcherEventArgs e)
        {
            Recover();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _process?.Dispose();
                    _watcher?.Dispose();
                }
                _process.Exited -= OnProcessExited;
                _batchStopProcess = null;              
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
