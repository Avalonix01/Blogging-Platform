using BlogPlatform.Features.DTOs.BlogDTOs;
using BlogPlatform.Features.Blogs.Create;
using BlogPlatform.Features.Blogs.Get;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace BlogPlatform.Features.Blogs;

[ApiController]
[Route("api/[controller]")]

public class BlogsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<BlogDto>>> GetBlogs()
    {
        var blogs = await mediator.Send(new GetBlogsQuery());
        return Ok(blogs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}