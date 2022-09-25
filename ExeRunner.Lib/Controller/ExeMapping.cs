using ExeRunner.Lib.Runner;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeRunner.Lib.Controller
{
    public class ExeMapping : ConcurrentDictionary<Guid, IExeRunner>, IDictionary<Guid, IExeRunner>, IDisposable
    {
        public void Dispose()
        {
            if (!IsEmpty)
            {
                foreach (KeyValuePair<Guid, IExeRunner> item in this)
                {
                    item.Value?.Dispose();
                }
            }

            Clear();
        }
    }
}
