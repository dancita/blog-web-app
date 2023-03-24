using BlogWebApp.Controllers;
using BlogWebApp.Data;
using BlogWebApp.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;
using BlogWebApp.ViewModels;

namespace BlogWebApp.Tests.Controllers
{
    public class BlogPostControllerTests
    {
        private readonly Mock<BlogWebAppContext> _context = new();

        [Fact]
        public void Index_ViewData_WithMultipleBlogPosts_ReturnsAsExpected()
        {
            // Arrange 
            _context.Setup(x => x.BlogPosts).ReturnsDbSet(TestDbData.GetMockBlogPostList());
            _context.Setup(x => x.BlogComment).ReturnsDbSet(TestDbData.GetMockBlogCommentList());

            var controller = new BlogPostController(_context.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ViewData.Model);
            var blogListItem = (List<BlogPostListItem>)result.ViewData.Model;
            Assert.Equal(2, blogListItem.Count);
            Assert.Equal("First post", blogListItem[0].Title);
            Assert.Equal(1, blogListItem[0].BlogPostId);
            Assert.Equal(2, blogListItem[0].NumberOfComments);
            Assert.Equal("Second post", blogListItem[1].Title);
            Assert.Equal(2, blogListItem[1].BlogPostId);
            Assert.Equal(0, blogListItem[1].NumberOfComments);
        }
    }
}