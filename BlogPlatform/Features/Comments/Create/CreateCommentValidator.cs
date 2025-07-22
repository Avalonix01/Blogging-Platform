using BlogPlatform.Features.DTOs.CommentDTOs;
using FluentValidation;

namespace BlogPlatform.Features.Comments.Create;

public class CreateCommentValidator : AbstractValidator<CommentCreateDto>
{
    public CreateCommentValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty().NotNull()
            .WithMessage("Content cannot be empty or null.");
    }
}
