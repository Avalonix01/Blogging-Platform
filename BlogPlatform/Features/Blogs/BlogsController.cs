using BlogPlatform.Features.DTOs.BlogDTOs;
using BlogPlatform.Features.Blogs.Create;
using BlogPlatform.Features.Blogs.Delete;
using BlogPlatform.Features.Blogs.Get;
using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Endpoints;
using MediatR;

namespace BlogPlatform.Features.Blogs;

[ApiController]
[Route("api/[controller]")]

public class BlogsController(IMediator mediator) : ControllerBase
{
    [HttpGet(ApiEndpoints.V1.Blogs.GetAll)]
    public async Task<ActionResult<List<BlogDto>>> GetBlogs()
    {
        var blogs = await mediator.Send(new GetBlogsQuery());
        return Ok(blogs);
    } 

    [HttpPost(ApiEndpoints.V1.Blogs.Create)]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpDelete(ApiEndpoints.V1.Blogs.Delete)] 
    public async Task<IActionResult> DeleteBlog(Guid blogId)
    {
        await mediator.Send(new DeleteBlogCommand(blogId));
        return NoContent();
    }
}