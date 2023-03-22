using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.Models
{
    public class BlogComment
    {
        [Key]
        public int CommentId { get; set; }
        public int BlogPostId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}
