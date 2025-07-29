using MediatR;

namespace BlogPlatform.Features.Blogs.Delete
{
    public record DeleteBlogCommand
        (Guid Id) : IRequest<bool>;
}
    