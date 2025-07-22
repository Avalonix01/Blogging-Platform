namespace BlogPlatform.Features.DTOs.CommentDTOs
{
    public record CommentCreateDto
        (string AuthorId, Guid BlogId, string Content);
}
