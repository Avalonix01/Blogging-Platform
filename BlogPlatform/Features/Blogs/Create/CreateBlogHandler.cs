using Microsoft.EntityFrameworkCore;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using MediatR;
using Mapster;

namespace BlogPlatform.Features.Blogs.Create;

public class CreateBlogHandler(BlogDbContext context)
    : IRequestHandler<CreateBlogCommand>
{ 
    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
         var blog = request.Adapt<Blog>();
         blog.AuthorId = request.AuthorId;
         
         var categoryExists = await context.Categories
             .AnyAsync(c => c.Id == request.CategoryId, cancellationToken);
         
         if (!categoryExists)
             throw new KeyNotFoundException("Category not found.");
        
         await context.Blogs.AddAsync(blog, cancellationToken);
         await context.SaveChangesAsync(cancellationToken);
    }
}