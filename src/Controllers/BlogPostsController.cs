using Microsoft.AspNetCore.Mvc;
using BlogWebApp.Data;

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
            return View(_context.BlogPosts.ToList());
        }


        // GET: BlogPosts
        public async Task<IActionResult> Details(int id)
        {
            return View(_context.BlogPosts.Where(x => x.BlogPostId == id).FirstOrDefault());
        }
    }
}
