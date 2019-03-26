using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POC.MediatR.Features;
using POC.MediatR.Features.Mediatr;
using POC.MediatR.Features.Plain;
using POC.MediatR.Infrastructure;
using POC.MediatR.Models;

namespace POC.MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Posts2Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public Posts2Controller(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/posts
        [HttpGet]
        public async Task<ActionResult<GetPosts2.Result>> Get()
        {
            return await _mediator.Send(new GetPosts2.Query(), HttpContext.RequestAborted);
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPost2.Result>> Get(int id)
        {
            return await _mediator.Send(new GetPost2.Query() { Id = id }, HttpContext.RequestAborted);
        }

        // POST api/posts
        [HttpPost]
        public async Task<ActionResult<AddPost2.Result>> Post([FromBody] AddPost2.Command command)
        {
            return await _mediator.Send(command, HttpContext.RequestAborted);
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
