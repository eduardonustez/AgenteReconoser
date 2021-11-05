using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo
{
    abstract class WorkerBase<T>
    {
        private readonly StatusBase<T> _status;
        public WorkerBase(StatusBase<T> status)
        {
            _status = status;
        }

        protected abstract ValueTask<bool> Process();
        protected abstract WorkerBase<T> BuildNext(StatusBase<T> status);

        public async Task Run()
        {
            _status.CancellationToken.ThrowIfCancellationRequested();
            ValueTask nextWorker = _status.TryStartNewWorker(BuildNext);

            while (true)
            {
                try
                {
                    _status.CancellationToken.ThrowIfCancellationRequested();
                    if (!await Process())
                        break;
                }
                catch (Exception ex)
                {
                    _status.AddException(ex);
                    break;
                }
            }
            await nextWorker;
        }
    }
}
