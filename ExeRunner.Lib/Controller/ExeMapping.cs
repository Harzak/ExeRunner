using ExeRunner.Lib.Runner;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Controller
{
    public class RunnerCollection : ConcurrentBag<IExeRunner>, IEnumerable<IExeRunner>, IDisposable
    {
        public void Dispose()
        {
            if (!IsEmpty)
            {
                foreach (IExeRunner item in this)
                {
                    item?.Dispose();
                }
                TryTake(out _);
            }
        }
    }
}
