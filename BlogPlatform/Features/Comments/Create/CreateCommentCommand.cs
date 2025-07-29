using MediatR;

namespace BlogPlatform.Features.Comments.Create
{
    public record CreateCommentCommand
        (string AuthorId, Guid BlogId, string Content) : IRequest<Guid>;
}