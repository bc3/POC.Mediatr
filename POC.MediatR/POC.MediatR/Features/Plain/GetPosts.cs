using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Features.Plain
{
    public class GetPosts : IExecutable<GetPosts.Query, GetPosts.Result>
    {
        private Storage _storage;

        public GetPosts(Storage storage)
        {
            _storage = storage;
        }

        public class Query
        {
        }


        public class Result
        {
            public IEnumerable<Post> Posts { get; set; }
        }

        public async Task<Result> Execute(Query input, CancellationToken cancellationToken)
        {
            return new Result()
            {
                Posts = _storage.All()
            };

        }
    }
}
