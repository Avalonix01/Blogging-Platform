using MediatR;

namespace BlogPlatform.Features.Categories.Delete
{
    public record DeleteCategoryCommand(Guid Id)
        : IRequest<bool>;
}