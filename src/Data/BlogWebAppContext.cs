using Microsoft.EntityFrameworkCore;
using BlogWebApp.Models;

namespace BlogWebApp.Data
{
    public class BlogWebAppContext : DbContext
    {
        public BlogWebAppContext (DbContextOptions<BlogWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPosts> BlogPosts { get; set; } = default!;
        public DbSet<BlogComment> BlogComment { get; set; } = default!;
    }
}
