using System.Security.Claims;
using MediatR;

namespace BlogPlatform.Features.Comments.Delete
{
    public record DeleteCommentCommand
        (Guid CommentId, string UserId) : IRequest;
}
