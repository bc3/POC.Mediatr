using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Features.Mediatr
{
    public class GetPosts2 : IRequestHandler<GetPosts2.Query, GetPosts2.Result>
    {
        private Storage _storage;

        public GetPosts2(Storage storage)
        {
            _storage = storage;
        }

        public class Query : IRequest<Result>
        {
        }


        public class Result : MessageResult
        {
            public IEnumerable<Post> Posts { get; set; }
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            return new Result()
            {
                Posts = _storage.All()
            };
        }
    }
}
