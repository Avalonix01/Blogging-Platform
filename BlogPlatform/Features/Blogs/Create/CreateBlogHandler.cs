using BlogPlatform.Features.DTOs.BlogDTOs;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using MediatR;
using Mapster;

namespace BlogPlatform.Features.Blogs.Create;

public class CreateBlogHandler(BlogDbContext context)
    : IRequestHandler<CreateBlogCommand>
{
    public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blogDto = new BlogCreateDto(request.Title, request.Content);
        var blog = blogDto.Adapt<Blog>();

        blog.AuthorId = request.AuthorId;

        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}