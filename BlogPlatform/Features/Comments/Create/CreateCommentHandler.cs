using BlogPlatform.Features.DTOs.CommentDTOs;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using Mapster;
using MediatR;

namespace BlogPlatform.Features.Comments.Create;

public class CreateCommandHandler(BlogDbContext context, ILogger<CreateCommandHandler> logger)
    : IRequestHandler<CreateCommentCommand, Guid>
{
    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = request.Adapt<Comment>();

        await context.Comments.AddAsync(comment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Comment created with ID {CommentId}", comment.Id);
        return comment.Id;
    }
}