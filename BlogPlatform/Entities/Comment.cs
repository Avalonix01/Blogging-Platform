using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Entities;

public class Comment
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid BlogId { get; private set; }
    public Blog Blog { get; private set; }
    public string AuthorId { get; private set; }
    
    [MaxLength(150)]
    public string Content { get; private set; }

    public Comment() { }
    
    public Comment(string content, Guid blogId, string authorId)
    {
        Id = Guid.CreateVersion7();
        CreatedAt = DateTime.UtcNow;
        Content = content;
        BlogId = blogId;
        AuthorId = authorId;
    }
}