using BlogPlatform.Features.DTOs.CategoryDTOs;
using Microsoft.EntityFrameworkCore;
using BlogPlatform.Data;
using Mapster;
using MediatR;

namespace BlogPlatform.Features.Categories.Get;

public class GetCategoriesHandler(BlogDbContext context)
    : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return categories.Adapt<List<CategoryDto>>();
    }
}