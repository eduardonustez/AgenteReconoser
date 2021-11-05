using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Utilidades.Paralelismo.Select
{
    class SelectWorker<In, Out> : WorkerBase<In>
    {
        public static SelectWorker<In, Out> Build(StatusBase<In> status)
        {
            if (status is SelectStatus<In, Out> selectStatus)
            {
                return new SelectWorker<In, Out>(selectStatus);
            }
            throw new ArgumentException($"El estado debe ser de tipo {nameof(SelectStatus<In, Out>)}", nameof(status));
        }

        protected override WorkerBase<In> BuildNext(StatusBase<In> status)
            => Build(status);

        SelectStatus<In, Out> _status;

        public SelectWorker(SelectStatus<In, Out> status):
            base(status)
        {
            _status = status
                ?? throw new ArgumentNullException(nameof(status));
        }

        protected override async ValueTask<bool> Process()
        {
            var (got, task)
                = await _status.SourceEnumerator.GetOne(PreRelease, _status.CancellationToken);
            if (!got)
                return false;
            var result = await task;
            if (!_status.PreserveOrder)
                await _status.QueueOutput(() => new ValueTask<Out>(result));
            return true;
        }

        async ValueTask<ValueTask<Out>> PreRelease(In item)
        {
            ValueTask<Out> ret = default;
            if (_status.PreserveOrder)
                await _status.QueueOutput(
                    () => ret = _status.Transformation(item, _status.CancellationToken)
                    );
            else
                ret = _status.Transformation(item, _status.CancellationToken);

            return ret;
        }
    }
}
