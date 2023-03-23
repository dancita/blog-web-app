using Microsoft.AspNetCore.Mvc;
using BlogWebApp.Data;
using BlogWebApp.ViewModels;
using BlogWebApp.Models;

namespace BlogWebApp.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly BlogWebAppContext _context;

        public BlogPostsController(BlogWebAppContext context)
        {
            _context = context;
        }

        // GET: BlogPosts
        public async Task<IActionResult> Index()
        {  
            var blogPostListItems = new List<BlogPostListItem>();
            List<BlogPosts> blogPosts = _context.BlogPosts.ToList();
            foreach (BlogPosts blogPost in blogPosts)
            {
                blogPostListItems.Add(new BlogPostListItem()
                {
                    Title = blogPost.Title,
                    NumberOfComments = _context.BlogComment.Where(x => x.BlogPostId == blogPost.BlogPostId).Count(),
                    BlogPostId= blogPost.BlogPostId
                });
            }            

            return View(blogPostListItems);
        }


        // GET: BlogPosts
        public async Task<IActionResult> Details(int id)
        {
            return View(_context.BlogPosts.Where(x => x.BlogPostId == id).FirstOrDefault());
        }
    }
}
