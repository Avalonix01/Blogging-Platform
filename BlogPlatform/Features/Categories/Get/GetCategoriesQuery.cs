using BlogPlatform.Features.DTOs.CategoryDTOs;
using MediatR;

namespace BlogPlatform.Features.Categories.Get
{
    public record GetCategoriesQuery
        : IRequest<List<CategoryDto>>;
}