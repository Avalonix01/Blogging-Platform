using MediatR;

namespace BlogPlatform.Features.Categories.Create
{
    public record CreateCategoryCommand
        (string Name) : IRequest<Guid>;
}