using Microsoft.AspNetCore.Mvc;
using BlogWebApp.Data;
using BlogWebApp.ViewModels;

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

            foreach (var blogPost in blogPosts)
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

        public ActionResult Details(int id)
        {
            return View(_context.BlogPosts.Where(x => x.BlogPostId == id).FirstOrDefault());
        }
    }
}
