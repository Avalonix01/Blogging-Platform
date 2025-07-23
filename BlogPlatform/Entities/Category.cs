using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Entities;

public class Category
{
    public Guid Id { get; private set; }
    
    [MaxLength(50)]
    public string Name { get; private set; }
    public List<Blog> Blogs { get; private set; } = [];

    public Category(string name)
    {
        Id = Guid.CreateVersion7();
        Name = name;
    }
}