using BlogPlatform.Features.DTOs.CommentDTOs;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using Mapster;
using MediatR;

namespace BlogPlatform.Features.Comments.Create;

public class CreateCommandHandler(
    BlogDbContext context, IHttpContextAccessor httpContextAccessor)
        : IRequestHandler<CreateCommentCommand>
{
    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var commentDto = new CommentCreateDto(request.AuthorId, request.BlogId, request.Content);
        var comment = commentDto.Adapt<Comment>();
        
        await context.Comments.AddAsync(comment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
