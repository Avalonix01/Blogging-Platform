using BlogPlatform.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace BlogPlatform.Features.Blogs.Delete;

public class DeleteBlogHandler(BlogDbContext context, ILogger<DeleteBlogHandler> logger)
    : IRequestHandler<DeleteBlogCommand, bool>
{
    public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (blog == null)
        {
            logger.LogWarning("Blog with ID {BlogId} not found", request.Id);
            return false;
        }

        context.Blogs.Remove(blog);
        await context.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Blog with ID {BlogId} deleted successfully", request.Id);
        return true;
    }
}