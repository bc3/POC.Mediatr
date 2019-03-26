using System.Threading;
using System.Threading.Tasks;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Features.Plain
{
    public class GetPost : IExecutable<GetPost.Query, GetPost.Result>
    {
        private readonly Storage _storage;

        public GetPost(Storage storage)
        {
            _storage = storage;
        }

        public class Query
        {
            public int Id { get; set; }
        }


        public class Result
        {
            public Post Post { get; set; }
        }

        public async Task<Result> Execute(Query input, CancellationToken cancellationToken)
        {
            var post = _storage.Get(input.Id);
            return new Result() {
                Post = post
            };
        }
    }
}
