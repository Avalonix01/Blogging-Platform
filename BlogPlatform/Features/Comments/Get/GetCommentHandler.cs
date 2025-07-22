using BlogPlatform.Features.DTOs.CommentDTOs;
using Microsoft.EntityFrameworkCore;
using BlogPlatform.Data;
using Mapster;
using MediatR;

namespace BlogPlatform.Features.Comments.Get;

public class GetCommentHandler(BlogDbContext context)
    : IRequestHandler<GetCommentQuery, List<CommentDto>>
{
    public async Task<List<CommentDto>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        var comments = await context.Comments
            .AsNoTracking()
            .Select(c =>  new {c.Id, c.Content}) 
            .ToListAsync(cancellationToken);

        return comments.Adapt<List<CommentDto>>();
    }
}