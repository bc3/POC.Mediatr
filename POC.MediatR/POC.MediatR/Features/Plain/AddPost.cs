using System.Threading;
using System.Threading.Tasks;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Features.Plain
{
    public class AddPost : IExecutable<AddPost.Command, AddPost.Result>
    {
        private readonly Storage _storage;

        public AddPost(Storage storage)
        {
            _storage = storage;
        }

        public class Command
        {
            public string text { get; set; }

        }


        public class Result
        {
            public int Id { get; set; }
        }

        public async Task<Result> Execute(Command input, CancellationToken cancellationToken)
        {
            var post = new Post() {Text = input.text};
            _storage.Add(post);
            return new Result() {
                Id = post.Id
            };
        }
    }
}
