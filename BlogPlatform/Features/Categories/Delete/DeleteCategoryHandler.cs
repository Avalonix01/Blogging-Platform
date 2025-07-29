using BlogPlatform.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Features.Categories.Delete;

public class DeleteCategoryHandler(BlogDbContext context, ILogger<DeleteCategoryHandler> logger)
    : IRequestHandler<DeleteCategoryCommand, bool>          
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        if (category == null)
        {
            logger.LogWarning("Category {Id} was not found", request.Id);
            return false;
        }
        
        context.Categories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Category {Id} was deleted successfully", request.Id);
        return true;
    }
}