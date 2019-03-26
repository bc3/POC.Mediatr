using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Features.Mediatr
{
    public class GetPost2 : IRequestHandler<GetPost2.Query, GetPost2.Result>
    {
        private readonly Storage _storage;

        public GetPost2(Storage storage)
        {
            _storage = storage;
        }

        public class Query : IRequest<Result>
        {
            public int Id { get; set; }
        }


        public class Result : MessageResult
        {
            public Post Post { get; set; }
        }

       

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {

            var post =  _storage.Get(request.Id);
            return new Result()
            {
                Post = post
            };
        }
    }
}
