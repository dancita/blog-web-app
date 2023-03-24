using Microsoft.EntityFrameworkCore;
using BlogWebApp.Models;

namespace BlogWebApp.Data
{
    public class BlogWebAppContext : DbContext
    {
        public BlogWebAppContext() { }

        public BlogWebAppContext (DbContextOptions<BlogWebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPost> BlogPosts { get; set; } = default!;
        public virtual DbSet<BlogComment> BlogComment { get; set; } = default!;
    }
}
