using BlogPlatform.Features.Comments.Delete;
using BlogPlatform.Features.Comments.Create;
using BlogPlatform.Features.Comments.Get;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace BlogPlatform.Features.Comments;

[ApiController]
[Route("api/[controller]")]

public class CommentsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetComments()
    {
        var comments = await mediator.Send(new GetCommentQuery());
        return Ok(comments);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
    
    [HttpDelete("{commentId::guid}")]
    public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentCommand command, Guid commentId)
    {
        await mediator.Send(new DeleteCommentCommand(command.CommentId, command.UserId));
        return NoContent();
    }
}