using BlogPlatform.Features.DTOs.BlogDTOs;
using Microsoft.EntityFrameworkCore;
using BlogPlatform.Data;
using MediatR;
using Mapster;

namespace BlogPlatform.Features.Blogs.Get;

public sealed class GetBlogsHandler(BlogDbContext context)
    : IRequestHandler<GetBlogsQuery, List<BlogDto>>
{
    public async Task<List<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await context.Blogs
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return blogs.Adapt<List<BlogDto>>();
    }
}