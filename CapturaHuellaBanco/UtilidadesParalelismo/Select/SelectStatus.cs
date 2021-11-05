using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo.Select
{
    class SelectStatus<In, Out> : StatusBase<In>, IAsyncEnumerator<Out>
    {
        public Func<In, CancellationToken, ValueTask<Out>> Transformation { get; private set; }
        public bool PreserveOrder { get; private set; }
        private ConcurrentQueue<ValueTask<Out>> _outBuffer;
        private SemaphoreSlim _outSemaphore;
        private SemaphoreSlim _bufferSemaphore;

        public SelectStatus(IAsyncEnumerable<In> source,
            Func<In, CancellationToken, ValueTask<Out>> transformation,
            CancellationToken cancellationToken,
            int maxParallelism,
            int maxBufferSize,
            bool preserveOrder) :
            base(source, cancellationToken, maxParallelism)
        {
            Transformation = transformation
                ?? throw new ArgumentNullException(nameof(transformation));
            PreserveOrder = preserveOrder;
            _outBuffer = new ConcurrentQueue<ValueTask<Out>>();
            _outSemaphore = new SemaphoreSlim(0);
            _bufferSemaphore = new SemaphoreSlim(maxBufferSize +
                (PreserveOrder ? maxParallelism - 1 : 0));
        }

        public new ValueTask DisposeAsync()
            => DisposeAsync(true);

        protected override async ValueTask DisposeAsync(bool disposing)
        {
            try
            {
                if (disposing)
                    await FinishWorkers();
            }
            finally{
                if (disposing)
                {
                    _outSemaphore?.Dispose();
                    _bufferSemaphore?.Dispose();
                }
                _outBuffer = null;
                _outSemaphore = null;
                _bufferSemaphore = null;
                await base.DisposeAsync(disposing);
            }
        }

        public async ValueTask QueueOutput(Func<ValueTask<Out>> output)
        {
            await _bufferSemaphore.WaitAsync(CancellationToken);
            _outBuffer.Enqueue(output());
            _outSemaphore.Release();
        }

        public Out Current { get; private set; }

        public async ValueTask<bool> MoveNextAsync()
        {
            _bufferSemaphore.Release();
            if (FirstWorkerTask == null)
                FirstWorkerTask = TryStartNewWorker(SelectWorker<In, Out>.Build)
                                .AsTask()
                                .ContinueWith((t) =>
                                {
                                    _outSemaphore?.Release();
                                });

            await _outSemaphore.WaitAsync(CancellationToken);
            if (!CancellationToken.IsCancellationRequested
                && _outBuffer.TryDequeue(out var next))
            {
                var ret = await next;
                if (!CancellationToken.IsCancellationRequested)
                {
                    Current = ret;
                    return true;
                }
            }
            return false;
        }
    }
}
