namespace BlogPlatform.Features.DTOs.BlogDTOs
{
    public record BlogDto
        (Guid Id, string Title,
            string Content, string CategoryName, Guid CategoryId);
}