using MediatR;

namespace BlogPlatform.Features.Blogs.Create
{
    public record CreateBlogCommand
        (string AuthorId, string Title,
            string Content, string CategoryName, Guid CategoryId) : IRequest;
}
