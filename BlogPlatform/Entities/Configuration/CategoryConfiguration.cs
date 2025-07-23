using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Entities.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(b => b.Blogs)
            .WithOne(c => c.Category);
    }
}