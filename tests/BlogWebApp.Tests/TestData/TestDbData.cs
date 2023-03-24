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
                    PublishedOn = DateTime.Now.AddYears(-1),
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
    }
}
