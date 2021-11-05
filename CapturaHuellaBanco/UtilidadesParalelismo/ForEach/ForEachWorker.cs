using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo.ForEach
{
    class ForEachWorker<T>: WorkerBase<T>
    {
        public static ForEachWorker<T> Build (StatusBase<T> status)
        {
            if(status is ForEachStatus<T> forEachStatus)
            {
                return new ForEachWorker<T>(forEachStatus);
            }
            throw new ArgumentException($"El estado debe ser de tipo {nameof(ForEachStatus<T>)}", nameof(status));
        }

        protected override WorkerBase<T> BuildNext(StatusBase<T> status)
            => Build(status);

        ForEachStatus<T> _status;

        public ForEachWorker(ForEachStatus<T> status)
            : base(status)
        {
            _status = status
                ?? throw new ArgumentNullException(nameof(status));
        }

        protected override async ValueTask<bool> Process()
        {
            var (got, next) = await _status.SourceEnumerator.GetOne(_status.CancellationToken);
            if (!got)
                return false;
            await _status.Action(next, _status.CancellationToken);
            return true;
        }
    }
}
