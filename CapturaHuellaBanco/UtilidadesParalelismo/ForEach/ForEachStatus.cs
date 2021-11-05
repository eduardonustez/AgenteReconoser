using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo.ForEach
{
    class ForEachStatus<T> : StatusBase<T>
    {
        public Func<T, CancellationToken, ValueTask> Action { get; private set; }
        public ForEachStatus(IAsyncEnumerable<T> source,
            Func<T, CancellationToken, ValueTask> action,
            CancellationToken cancellationToken,
            int maxParallelism) :
            base(source, cancellationToken, maxParallelism)
        {
            Action = action;
        }

        public async Task Run()
        {
            await (FirstWorkerTask = TryStartNewWorker(ForEachWorker<T>.Build).AsTask());

            if (Exceptions != null)
                throw new AggregateException(Exceptions);
        }
    }
}
