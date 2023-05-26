using Blogger.API.Models;
using Blogger.API.Models.DataTransferObjects;
using Blogger.API.Requests.Commands;
using Blogger.API.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:guid}", Name = "BlogById")]
    public async Task<ActionResult> GetById(Guid id)
    {
        
        var blog = await _mediator.Send(new GetBlogByIdQuery(id));
        return blog != null ? Ok(blog) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Blog>> CreateBlog(CreateBlogRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var newBlog = await _mediator.Send(new CreateBlogCommand(request));
        return CreatedAtRoute("BlogById", new { id = newBlog.Id }, newBlog);
    }
}
