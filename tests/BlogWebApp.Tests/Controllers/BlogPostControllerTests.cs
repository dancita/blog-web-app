using BlogWebApp.Controllers;
using BlogWebApp.Data;
using BlogWebApp.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;
using BlogWebApp.ViewModels;
using BlogWebApp.Models;

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

        [Fact]
        public void Index_ViewData_WithNoBlogPosts_ThrowsError()
        {
            // Arrange 
            _context.Setup(x => x.BlogPosts).ReturnsDbSet(TestDbData.GetEmptyBlogPostList());

            var controller = new BlogPostController(_context.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ViewData.Model);
            var errorResult = (Error)result.ViewData.Model;
            Assert.Equal("There are no blog posts to show.", errorResult.Message);
            Assert.Equal("Please come back later.", errorResult.ErrorDetails);
        }

        [Fact]
        public void Details_ViewData_ValidId_ReturnsAsExpexted()
        {
            // Arrange 
            _context.Setup(x => x.BlogPosts).ReturnsDbSet(TestDbData.GetMockBlogPostList());

            var controller = new BlogPostController(_context.Object);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ViewData.Model);
            var blogPostResult = (BlogPost)result.ViewData.Model;
            Assert.Equal("This is my first blog post.", blogPostResult.Body);
            Assert.Equal("First post", blogPostResult.Title);
            Assert.Equal(1, blogPostResult.BlogPostId);
            Assert.Equal(new DateTime(2019, 05, 09, 9, 15, 0), blogPostResult.PublishedOn);
        }

        [Fact]
        public void Details_ViewData_InvalidId_ThrowsError()
        {
            // Arrange 
            _context.Setup(x => x.BlogPosts).ReturnsDbSet(TestDbData.GetMockBlogPostList());

            var controller = new BlogPostController(_context.Object);

            // Act
            var result = controller.Details(4) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ViewData.Model);
            var errorResult = (Error)result.ViewData.Model;
            Assert.Equal("The blog post isn't found", errorResult.Message);
            Assert.Equal("Please check if you provided a valid blog post id", errorResult.ErrorDetails);
        }
    }
}