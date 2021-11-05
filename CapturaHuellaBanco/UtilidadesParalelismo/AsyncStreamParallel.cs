using Olimpia.Utilidades.Paralelismo.ForEach;
using Olimpia.Utilidades.Paralelismo.Select;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo
{
    public class AsyncStreamParallel
    {
        public static Task ForEach<T>(
            IAsyncEnumerable<T> source,
            Func<T, ValueTask> action,
            CancellationToken cancellationToken = default,
            int? maxParallelism = null)
            => ForEach(
                source,
                (s, _) => action(s),
                cancellationToken,
                maxParallelism);

        public static Task ForEach<T>(
            IAsyncEnumerable<T> source,
            Func<T, CancellationToken, ValueTask> action,
            CancellationToken cancellationToken = default,
            int? maxParallelism = null)
            => new ForEachStatus<T>(
                    source,
                    action,
                    cancellationToken,
                    maxParallelism ?? Environment.ProcessorCount)
                .Run();

        public static IAsyncEnumerable<Out> Select<In, Out>(
            IAsyncEnumerable<In> stream,
            Func<In, ValueTask<Out>> transformation,
            int? maxParallelism = null,
            int maxBufferSize = 0,
            bool preserveOrder = true)
            => Select(
                    stream,
                    (i, _) => transformation(i),
                    maxParallelism,
                    maxBufferSize,
                    preserveOrder
                );

        public static IAsyncEnumerable<Out> Select<In, Out>(
            IAsyncEnumerable<In> stream,
            Func<In, CancellationToken, ValueTask<Out>> transformation,
            int? maxParallelism = null,
            int maxBufferSize = 0,
            bool preserveOrder = true)
            => new SelectEnumerable<In, Out>(
                stream,
                transformation,
                maxParallelism ?? Environment.ProcessorCount,
                maxBufferSize,
                preserveOrder);

    }
}
