using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.Models
{
    public class BlogPosts
    {
        [Key]
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}
