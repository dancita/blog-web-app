using Microsoft.AspNetCore.Mvc;
using BlogWebApp.Data;
using BlogWebApp.ViewModels;
using Microsoft.IdentityModel.Tokens;
using BlogWebApp.Models;

namespace BlogWebApp.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly BlogWebAppContext _context;

        public BlogPostController(BlogWebAppContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {  
            var blogPostListItems = new List<BlogPostListItem>();
            var blogPosts = _context.BlogPosts.ToList();

            if (blogPosts.IsNullOrEmpty()) {
                return View("Error", new Error(){
                    Message = "There are no blog posts to show.",
                    ErrorDetails = "Please come back later."
                });
            }

            foreach (var blogPost in blogPosts)
            {
                blogPostListItems.Add(new BlogPostListItem()
                {
                    Title = blogPost.Title,
                    NumberOfComments = _context.BlogComment.Where(x => x.BlogPostId == blogPost.BlogPostId).Count(),
                    BlogPostId = blogPost.BlogPostId
                });
            }            

            return View(blogPostListItems);
        }

        public ActionResult Details(int id)
        {
            var blogPost = _context.BlogPosts.Where(x => x.BlogPostId == id).FirstOrDefault();
            if (blogPost == null)
            {
                return View("Error", new Error()
                {
                    Message = "The blog post isn't found",
                    ErrorDetails = "Please check if you provided a valid blog post id"
                });
            }
            return View(blogPost);
        }
    }
}
