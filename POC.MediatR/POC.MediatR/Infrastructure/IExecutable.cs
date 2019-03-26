using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POC.MediatR.Infrastructure
{
    public interface IExecutable<TInput, TOutput>
    {
        Task<TOutput> Execute(TInput input, CancellationToken cancellationToken);
    }
}
