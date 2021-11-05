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
    public class AsyncStreamParallelSelectTest
    {
        private IAsyncEnumerable<int> _input;
        private IEnumerable<int> _expected;
        private ITestOutputHelper _output;
        public AsyncStreamParallelSelectTest(ITestOutputHelper output)
        {
            _expected = Enumerable.Range(0, 10)
                            .ToArray();
            _input = ToAsyncEnumerable(_expected);
            _output = output;
        }

        [Fact]
        public async Task TasksShouldRunInParallel_ShouldRunIn15SecAprox()
        {
            var output = AsyncStreamParallel.Select(_input, async (o) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");
                await Task.Delay(5000);
                _output.WriteLine($"procesado {o}- {DateTime.Now}");
                return o;
            }, maxParallelism: 5);

            var actual = new List<int>();
            await foreach (var obj in output)
            {
                actual.Add(obj);
            }
            Assert.Equal(_expected, actual);
        }

        [Fact]
        public async Task FirstWorkerToFinishShouldKeepWorking_ShouldRunIn11SecAprox()
        {
            var output = AsyncStreamParallel.Select(_input, async (o) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");
                if (o == 0)
                    await Task.Delay(10000);
                else
                    await Task.Delay(1000);
                _output.WriteLine($"procesado {o}- {DateTime.Now}");
                return o;
            }, maxParallelism: 2, maxBufferSize: 8);

            var actual = new List<int>();
            await foreach (var obj in output)
            {
                actual.Add(obj);
            }
            Assert.Equal(_expected, actual);
        }

        [Fact]
        public async Task ProcessingShouldWaitIfBufferFull_ShouldRunIn12SecAprox()
        {
            // The second thread will be able to buffer 7 completed answers (items 2 through 8) while the first one is still processing the first item
            //   after processing the 9th item, it will have to wait before pushing it to the buffer. Once the first item is processed, any of the workers
            //   can take it and finish the loop.
            var output = AsyncStreamParallel.Select(_input, async (o) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");
                if (o == 0)
                    await Task.Delay(10000);
                else
                    await Task.Delay(1000);
                _output.WriteLine($"procesado {o}- {DateTime.Now}");
                return o;
            }, maxParallelism: 2, maxBufferSize: 7);

            var actual = new List<int>();
            await foreach (var obj in output)
            {
                actual.Add(obj);
            }
            Assert.Equal(_expected, actual);
        }

        [Fact]
        public async Task ItemsShouldBeEagerlyReturnedIfNotPreserveOrder_ShouldRunIn11SecAprox()
        {
            var output = AsyncStreamParallel.Select(_input, async (o) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");
                if (o == 0)
                    await Task.Delay(10000);
                else
                    await Task.Delay(1000);
                _output.WriteLine($"procesado {o}- {DateTime.Now}");
                return o;
            }, maxParallelism: 2, maxBufferSize: 7, preserveOrder: false);

            var actual = new List<int>();
            await foreach (var obj in output)
            {
                actual.Add(obj);
            }
            Assert.Equal(_expected.Skip(1).Take(8), actual.Take(8));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(10)]
        public async Task TestCancel_ShouldRunIn2_5SecAprox(int take)
        {
            var tokenSource = new CancellationTokenSource();
            _expected = _expected.Take(take);
            _input = ToAsyncEnumerable(_expected.Take(take));

            var output = AsyncStreamParallel.Select(_input, async (o, c) =>
            {
                _output.WriteLine($"procesando {o}- {DateTime.Now}");

                try
                {
                    await Task.Delay(1000, c);
                    _output.WriteLine($"procesado {o}- {DateTime.Now}");
                }
                catch (OperationCanceledException)
                {
                    _output.WriteLine($"cancelado procesamiento {o}- {DateTime.Now}");
                }

                return o;
            }, maxBufferSize: 10);

            var receivedItems = 0;

            var t = Task.Delay(2500)
                        .ContinueWith((_) => tokenSource.Cancel());

            await Assert.ThrowsAsync<AggregateException>(async () =>
            {
                await foreach (var obj in output.WithCancellation(tokenSource.Token))
                {
                    _output.WriteLine($"obtenido {obj} como procesado");
                    receivedItems++;
                }
            });

            Assert.Equal(1, receivedItems);
        }


        [Fact]
        public async Task TestException_ShouldRunIn1_5SecAprox()
        {
            var expectedEx = new Exception();
            var actualEx = await Assert.ThrowsAsync<AggregateException>(async () =>
            {
                await foreach (var x in AsyncStreamParallel.Select(_input, async (o) =>
                {
                    _output.WriteLine($"procesando {o}- {DateTime.Now}");

                    await Task.Delay(500);
                    throw expectedEx;
                    return o;
                }))
                {

                }
            });

            Assert.Contains(expectedEx, actualEx.InnerExceptions);
        }

        [Fact]
        public async Task TestExceptionInBody_ShouldRunIn1_5SecAprox()
        {
            var expectedEx = new Exception();
            var actualEx = await Assert.ThrowsAsync<Exception>(async () =>
            {
                await foreach (var x in AsyncStreamParallel.Select(_input, async (o) =>
                {
                    _output.WriteLine($"procesando {o}- {DateTime.Now}");

                    await Task.Delay(500);
                    return o;
                }))
                {
                    throw expectedEx;
                }
            });

            Assert.Equal(expectedEx, actualEx);
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
