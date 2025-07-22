using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Entities;

public class Blog
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    
    [MaxLength(100)]
    public string Title { get; private set; }
    
    [MaxLength(1000)]
    public string Content { get; private set; }
    public List<Comment> Comments { get; private set; } = [];

    [MaxLength(50)]
    public string AuthorId { get; set; }
    
    public Blog() { }

    public Blog(string title, string content, string authorId)
    {
        Id = Guid.CreateVersion7();
        Title = title;
        Content = content;
    }
}
