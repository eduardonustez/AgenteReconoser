using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Olimpia.Utilidades.Paralelismo.Test
{
    public class AsyncStreamParallelForEachTest
    {
        private IAsyncEnumerable<int> _input;
        private IEnumerable<int> _expected;
        private ITestOutputHelper _output;
        public AsyncStreamParallelForEachTest(ITestOutputHelper output)
        {
            _expected = Enumerable.Range(0, 10)
                            .ToArray();
            _input = ToAsyncEnumerable(_expected);
            _output = output;
        }

        [Fact]
        public async Task TasksShouldRunInParallel_ShouldRunIn15SecAprox()
        {
            await AsyncStreamParallel.ForEach(_input, async (o) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");
                await Task.Delay(5000);
                _output.WriteLine($"procesado {o}- {DateTime.Now}");
            }, maxParallelism: 5);
        }

        [Fact]
        public async Task FirstWorkerToFinishShouldKeepWorking_ShouldRunIn11SecAprox()
        {
            await AsyncStreamParallel.ForEach(_input, async (o) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");
                if (o == 0)
                    await Task.Delay(10000);
                else
                    await Task.Delay(1000);
                _output.WriteLine($"procesado {o}- {DateTime.Now}");
            }, maxParallelism: 2);
        }

        [Fact]
        public async Task TestCancel_ShouldRunIn2_5SecAprox()
        {
            var tokenSource = new CancellationTokenSource();
            var locker = new object();

            var receivedItems = 0;

            var t = Task.Delay(2500)
                        .ContinueWith((_) => tokenSource.Cancel());

            var actualEx = await Assert.ThrowsAsync<AggregateException>(() =>
            AsyncStreamParallel.ForEach(_input, async (o, c) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");

                try
                {
                    await Task.Delay(1000, c);
                    lock (locker)
                    {
                        receivedItems++;
                    }
                    _output.WriteLine($"procesado {o}- {DateTime.Now}");
                }
                catch (OperationCanceledException)
                {
                    _output.WriteLine($"cancelado procesamiento {o}- {DateTime.Now}");
                }
            }, tokenSource.Token));

            Assert.Equal(1, receivedItems);
        }

        [Fact]
        public async Task TestException_ShouldRunIn1_5SecAprox()
        {
            var expectedEx = new Exception();
            var actualEx = await Assert.ThrowsAsync<AggregateException>(() =>
            AsyncStreamParallel.ForEach(_input, async (o, c) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");

                await Task.Delay(500, c);
                throw expectedEx;
                
            }));

            Assert.Contains(expectedEx, actualEx.InnerExceptions);
        }

        private async IAsyncEnumerable<T> ToAsyncEnumerable<T>(IEnumerable<T> syncStream, [EnumeratorCancellation] CancellationToken ct = default)
        {
            foreach (var obj in syncStream)
            {
                _output.WriteLine($"pidiendo {obj} del back- {DateTime.Now}");
                try
                {
                    await Task.Delay(1000, ct);
                }
                catch (OperationCanceledException)
                {
                    _output.WriteLine($"cancelada obtencion {obj} del back- {DateTime.Now}");
                }
                yield return obj;
            }
        }
    }
}
