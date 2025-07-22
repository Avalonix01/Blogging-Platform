using BlogPlatform.Features.DTOs.BlogDTOs;
using FluentValidation;

namespace BlogPlatform.Features.Blogs.Create;

public sealed class CreateBlogValidator : AbstractValidator<BlogCreateDto>
{
    public CreateBlogValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().NotNull()
            .Length(3, 50); 

        RuleFor(b => b.Content)
            .NotEmpty().NotNull()
            .Length(3, 500);
    }
}
