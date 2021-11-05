using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo
{
    abstract class StatusBase<T> : IAsyncDisposable
    {
        public ConcurrentAsyncEnumeratorWrapper<T> SourceEnumerator { get; private set; }
        public CancellationToken CancellationToken { get; private set; }
        public int MaxParallelism { get; private set; }
        public int RunningWorkers { get; protected set; }
        public ConcurrentBag<Exception> Exceptions { get; private set; }
        public Task FirstWorkerTask { get; protected set; }
        private CancellationTokenSource _cancellation;

        public StatusBase(IAsyncEnumerable<T> source,
            CancellationToken cancellationToken,
            int maxParallelism)
        {
            _cancellation = new CancellationTokenSource();
            cancellationToken.Register(() => _cancellation.Cancel());
            CancellationToken = _cancellation.Token;
            SourceEnumerator = new ConcurrentAsyncEnumeratorWrapper<T>(source.GetAsyncEnumerator(CancellationToken));
            MaxParallelism = maxParallelism;
            RunningWorkers = 0;
        }

        public ValueTask DisposeAsync()
            => DisposeAsync(true);

        protected virtual async Task FinishWorkers()
        {
            AggregateException ex = null;
            bool canceled = CancellationToken.IsCancellationRequested;
            if(!canceled && Exceptions != null)
                    ex = new AggregateException(Exceptions);

            _cancellation.Cancel();
            await FirstWorkerTask;

            if (canceled && Exceptions != null)
                    ex = new AggregateException(Exceptions);
            
            if (ex != null)
                throw ex;
        }

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await (SourceEnumerator?.DisposeAsync() ?? default);
                _cancellation?.Dispose();
            }
            SourceEnumerator = null;
            _cancellation = null;
        }

        public void AddException(Exception ex)
        {
            if (Exceptions == null)
            {
                lock (this)
                {
                    Exceptions ??= new ConcurrentBag<Exception>();
                }
            }
            Exceptions.Add(ex);
            _cancellation.Cancel();
        }

        public ValueTask TryStartNewWorker(Func<StatusBase<T>, WorkerBase<T>> builder)
        {
            if (RunningWorkers >= MaxParallelism)
                return default;
            RunningWorkers++;
            return new ValueTask(builder(this).Run());
        }

    }
}
