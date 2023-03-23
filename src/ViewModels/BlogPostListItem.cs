using System.ComponentModel;

namespace BlogWebApp.ViewModels
{
    public class BlogPostListItem
    {
        public string Title { get; set; }

        [DisplayName("Number of comments")]
        public int NumberOfComments { get; set; }
        public int BlogPostId { get; set; }


    }
}
