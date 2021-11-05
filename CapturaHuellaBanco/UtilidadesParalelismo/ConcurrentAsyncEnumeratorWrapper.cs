using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo
{
    class ConcurrentAsyncEnumeratorWrapper<T> : IAsyncDisposable
    {
        IAsyncEnumerator<T> _wrapped;
        SemaphoreSlim _semaphore;
        ValueTask<(bool, T)> _current;
        public ConcurrentAsyncEnumeratorWrapper(IAsyncEnumerator<T> wrapped)
        {
            _wrapped = wrapped
                ?? throw new ArgumentNullException(nameof(wrapped));
            _semaphore = new SemaphoreSlim(1);
            _current = GetNext();
        }

        public ValueTask DisposeAsync()
            => DisposeAsync(true);

        protected async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await (_wrapped?.DisposeAsync() ?? default);
                _semaphore?.Dispose();
            }
            _wrapped = null;
            _semaphore = null;
        }

        public ValueTask<(bool, T)> GetOne(CancellationToken cancellationToken = default)
            => GetOne<T>(x => new ValueTask<T>(x), cancellationToken);

        public async ValueTask<(bool, Out)> GetOne<Out>(
            Func<T, ValueTask<Out>> transformation,
            CancellationToken cancellationToken = default)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                var (got, next) = await _current;
                _current = GetNext();
                return (got, got ? await transformation(next) : default);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async ValueTask<(bool, T)> GetNext()
        {
            bool got = await _wrapped.MoveNextAsync();
            return (got, got ? _wrapped.Current : default);
        }
    }
}
