using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POC.MediatR.Features.Mediatr.Notifications;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Features.Mediatr
{
    public class AddPost2 : IRequestHandler<AddPost2.Command, AddPost2.Result>
    {
        private readonly Storage _storage;
        private readonly IMediator _mediator;

        public AddPost2(Storage storage, IMediator mediator)
        {
            _storage = storage;
            _mediator = mediator;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            var post = new Post() { Text = request.text };
            _storage.Add(post);
            await _mediator.Publish(new PostNotifier() { Info = "Post added" }, cancellationToken);
            return new AddPost2.Result()
            {
                Id = post.Id
            };
        }

        public class Command : IRequest<Result>
        {
            public string text { get; set; }

        }

        public class Result : MessageResult
        {
            public int Id { get; set; }
        }
    }
}
