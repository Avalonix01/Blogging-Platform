using BlogPlatform.Features.DTOs.BlogDTOs;
using MediatR;

namespace BlogPlatform.Features.Blogs.Get
{
    public record GetBlogsQuery
        : IRequest<List<BlogDto>>;
}