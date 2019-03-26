using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POC.MediatR.Features.Mediatr;

namespace POC.MediatR.Infrastructure.Behaviors
{
    [DebuggerStepThrough]
    public class DelayBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //could add logging here
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var response = await next();

            var messageResult = response as MessageResult;
            if (messageResult != null)
                messageResult.Delay = stopwatch.ElapsedMilliseconds;

            return response;
        }
    }
}