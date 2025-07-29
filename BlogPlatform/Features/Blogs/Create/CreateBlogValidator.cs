using BlogPlatform.Features.DTOs.BlogDTOs;
using FluentValidation;

namespace BlogPlatform.Features.Blogs.Create;

public sealed class CreateBlogValidator : AbstractValidator<BlogCreateDto>
{
    public CreateBlogValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().NotNull().WithMessage("Title is required")
            .Length(3, 50); 

        RuleFor(b => b.Content)
            .NotEmpty().NotNull().WithMessage("Content is required")
            .Length(3, 500);
    }
}
