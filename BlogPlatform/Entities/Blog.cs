using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Entities;

public class Blog
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }

    public List<Comment> Comments { get; private set; } = [];
    public string AuthorId { get; set; }

    public Guid CategoryId { get; private set; }
    public string CategoryName { get; set; }
    public Category? Category { get; private set; } 
        
    public Blog() { }

    public Blog(string title, string content, string categoryName)
    {
        Id = Guid.CreateVersion7();
        Title = title;
        Content = content;
        CategoryName = categoryName;
    }
}
