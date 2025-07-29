using Microsoft.EntityFrameworkCore;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using MediatR;
using Mapster;

namespace BlogPlatform.Features.Blogs.Create;

public class CreateBlogHandler(BlogDbContext context, ILogger<CreateBlogHandler> logger)
    : IRequestHandler<CreateBlogCommand>
{
    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = request.Adapt<Blog>();
        blog.AuthorId = request.AuthorId;

        var categoryExists = await context.Categories
            .AnyAsync(c => c.Id == request.CategoryId, cancellationToken);

        if (!categoryExists)
        {
            logger.LogWarning("Category with ID {CategoryId} does not exist", request.CategoryId);
            throw new ArgumentException("Category does not exist");
        }

        blog.CategoryName = await GetCategoryName(request.CategoryId, cancellationToken);

        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Blog created with ID {BlogId} by Author {AuthorId}", blog.Id, blog.AuthorId);
    }

    private async Task<string> GetCategoryName(Guid categoryId, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        if (category == null)
        {
            logger.LogWarning("Category with ID {CategoryId} not found in GetCategoryName", categoryId);
            throw new ArgumentException("Category does not exist");
        }

        return category.Name;
    }
}