using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using POC.MediatR.Features.Mediatr.Notifications;
using POC.MediatR.Models;

namespace POC.MediatR.Infrastructure
{
    public class Storage
    {
        private List<Post> Posts = new List<Post>();

        public Storage()
        {
            Posts.Add(new Post() { Id = 1, Text = "Hello world 1" });
            Posts.Add(new Post() { Id = 2, Text = "Hello world 2" });
            Posts.Add(new Post() { Id = 3, Text = "Hello world 3" });
        }

        public void Add(Post post)
        {
            post.Id = Posts.Max(x => x.Id) + 1;
            Posts.Add(post);

        }

        public Post Get(int id)
        {
            return Posts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Post> All()
        {
            return Posts;
        }
    }
}
