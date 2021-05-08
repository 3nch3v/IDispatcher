namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : Controller
    {
        private readonly IBlogService blogServie;
        private readonly UserManager<ApplicationUser> userManager;

        public BlogController(
             IBlogService blogServie,
             UserManager<ApplicationUser> userManager)
        {
            this.blogServie = blogServie;
            this.userManager = userManager;
        }

        public IActionResult AllPosts()
        {
            var posts = new AllBlogPostsViewModel()
            {
                Posts = this.blogServie.GetAllBlogPosts<BlogPostViewModel>(),
            };

            return this.View(posts);
        }

        [Authorize]
        public async Task<IActionResult> Create(BlogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.blogServie.CreatPostAsync(input, user.Id);

            return this.Redirect("/Blog/AllPosts");
        }

        public IActionResult Post(int id)
        {
            var post = this.blogServie.GetPost<BlogPostViewModel>(id);
            return this.View(post);
        }
    }
}
