using BlogPlatform.Data;
using BlogPlatform.Entities;
using Mapster;
using MediatR;

namespace BlogPlatform.Features.Categories.Create;

public class CreateCategoryHandler(BlogDbContext context)
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = request.Adapt<Category>();
        
        await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}