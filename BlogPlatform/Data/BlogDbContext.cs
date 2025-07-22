using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlogPlatform.Entities;

namespace BlogPlatform.Data;

public sealed class BlogDbContext(DbContextOptions opts)
    : IdentityDbContext<IdentityUser>(opts)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
        base.OnModelCreating(builder);
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
