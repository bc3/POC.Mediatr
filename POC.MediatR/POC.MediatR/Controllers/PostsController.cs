using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POC.MediatR.Features;
using POC.MediatR.Features.Plain;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IExecutable<GetPost.Query, GetPost.Result> _getPost;
        private readonly IExecutable<GetPosts.Query, GetPosts.Result> _getPosts;
        private readonly IExecutable<AddPost.Command, AddPost.Result> _addPost;

        public PostsController(
            IExecutable<GetPost.Query, GetPost.Result> getPost,
            IExecutable<GetPosts.Query, GetPosts.Result> getPosts,
            IExecutable<AddPost.Command, AddPost.Result> addPost)
        {
            _getPost = getPost;
            _getPosts = getPosts;
            _addPost = addPost;
        }

        // GET api/posts
        [HttpGet]
        public async Task<ActionResult<GetPosts.Result>> Get()
        {
            return await _getPosts.Execute(new GetPosts.Query(), HttpContext.RequestAborted);
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPost.Result>> Get(int id)
        {
            return await _getPost.Execute(new GetPost.Query() { Id = id }, HttpContext.RequestAborted);
        }

        // POST api/posts
        [HttpPost]
        public async Task<ActionResult<AddPost.Result>> Post([FromBody] AddPost.Command command)
        {
            return await _addPost.Execute(command, HttpContext.RequestAborted);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
