using BlogWebApp.Models;

namespace BlogWebApp.Tests.TestData
{
    public class TestDbData
    {
        public static List<BlogPost> GetMockBlogPostList()
        {
            return new List<BlogPost>()
            {
                new BlogPost
                {
                    BlogPostId = 1,
                    Body = "This is my first blog post.",
                    PublishedOn = new DateTime(2019,05,09,9,15,0),
                    Title = "First post",
                },
                new BlogPost
                {
                    BlogPostId = 2,
                    Body = "Second blog post.",
                    PublishedOn = DateTime.Now,
                    Title = "Second post",
                }
            };
        }

        public static List<BlogComment> GetMockBlogCommentList()
        {
            return new List<BlogComment>()
            {
                new BlogComment
                {
                    BlogPostId = 1,
                    Comment = "This was a great post",
                    CommentedOn = DateTime.Now.AddMonths(-6),
                    CommentId= 1
                },
                new BlogComment
                {
                    BlogPostId = 1,
                    Comment = "So true!!",
                    CommentedOn = DateTime.Now,
                    CommentId= 2,
                }
            };
        }

        public static List<BlogPost> GetEmptyBlogPostList()
        {
            return new List<BlogPost>();
        }
    }
}
