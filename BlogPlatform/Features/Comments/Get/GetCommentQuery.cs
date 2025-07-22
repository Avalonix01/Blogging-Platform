using BlogPlatform.Features.DTOs.CommentDTOs;
using MediatR;

namespace BlogPlatform.Features.Comments.Get
{
    public record GetCommentQuery
        : IRequest<List<CommentDto>>;
}
