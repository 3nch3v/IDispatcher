namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BlogsController : Controller
    {
        private readonly IBlogService blogServie;
        private readonly UserManager<ApplicationUser> userManager;

        public BlogsController(
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
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(BlogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            input.UserId = user.Id;
            await this.blogServie.CreatPostAsync(input);

            return this.RedirectToAction(nameof(this.AllPosts));
        }

        public IActionResult Post(int id)
        {
            var post = this.blogServie.GetPost<BlogPostViewModel>(id);
            return this.View(post);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var editPost = this.blogServie.GetPost<EditBlogPostInputmodel>(id);
            return this.View(editPost);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditBlogPostInputmodel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.blogServie.UpdatePostAsync(id, input);
            return this.RedirectToAction(nameof(this.Post), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.blogServie.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.AllPosts));
        }
    }
}
