using BlogPlatform.Features.DTOs.CategoryDTOs;
using FluentValidation;

namespace BlogPlatform.Features.Categories.Create;

public class CreateCategoryValidator
    : AbstractValidator<CategoryCreateDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().NotNull().WithMessage("Category name cannot be empty.")
            .Length(1, 50).WithMessage("Category name must be between 1 and 50 characters long.");
    }
}
