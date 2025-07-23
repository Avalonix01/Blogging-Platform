using BlogPlatform.Features.DTOs.CommentDTOs;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using Mapster;
using MediatR;

namespace BlogPlatform.Features.Comments.Create;

public class CreateCommandHandler(
    BlogDbContext context)
        : IRequestHandler<CreateCommentCommand>
{
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = request.Adapt<Comment>();
        
        await context.Comments.AddAsync(comment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
