namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BlogsController : Controller
    {
        private readonly IBlogService blogServie;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public BlogsController(
             IBlogService blogServie,
             UserManager<ApplicationUser> userManager,
             IWebHostEnvironment environment)
        {
            this.blogServie = blogServie;
            this.userManager = userManager;
            this.environment = environment;
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

            string imgPath = $"{this.environment.WebRootPath}/img/{input.Picture.FileName}";
            var user = await this.userManager.GetUserAsync(this.User);
            await this.blogServie.CreatPostAsync(input, user.Id, imgPath);

            return this.RedirectToAction(nameof(this.AllPosts));
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

        public IActionResult AllPosts(int page = GlobalConstants.DefaultPageNumber)
        {
            var posts = new AllBlogPostsViewModel()
            {
                Posts = this.blogServie.GetAllBlogPosts<BlogPostViewModel>(page, GlobalConstants.BlogPageEntitiesCount),
                Page = page,
                BlogPostsCount = this.blogServie.BlogPostsCount(),
            };

            return this.View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = this.blogServie.GetPost<BlogPostViewModel>(id);
            return this.View(post);
        }
    }
}
