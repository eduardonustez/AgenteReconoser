using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo.Select
{
    class SelectEnumerable<In, Out> : IAsyncEnumerable<Out>
    {
        private IAsyncEnumerable<In> _source;
        private Func<In, CancellationToken, ValueTask<Out>> _transformation;
        private int _maxParallelism;
        private int _maxBufferSize;
        private bool _preserveOrder;
        public SelectEnumerable(IAsyncEnumerable<In> source,
            Func<In, CancellationToken, ValueTask<Out>> transformation,
            int maxParallelism,
            int maxBufferSize,
            bool preserveOrder)
        {
            _source = source ??
                throw new ArgumentNullException(nameof(source));
            _transformation = transformation ??
                throw new ArgumentNullException(nameof(transformation));
            _maxParallelism = maxParallelism;
            _maxBufferSize = maxBufferSize;
            _preserveOrder = preserveOrder;
        }

        public IAsyncEnumerator<Out> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => new SelectStatus<In, Out>(
                _source,
                _transformation,
                cancellationToken,
                _maxParallelism,
                _maxBufferSize,
                _preserveOrder
                );
    }
}
