namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
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
        private readonly IStringValidatorService stringValidatorService;

        public BlogsController(
            UserManager<ApplicationUser> userManager,
            IBlogService blogServie,
            IWebHostEnvironment environment,
            IStringValidatorService stringValidatorService)
        {
            this.blogServie = blogServie;
            this.userManager = userManager;
            this.environment = environment;
            this.stringValidatorService = stringValidatorService;
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
            if (!this.ModelState.IsValid
                || !this.stringValidatorService.IsStringValidDecoded(input.Body, GlobalConstants.DefaultBodyStringMinLength))
            {
                return this.View();
            }

            string pictureDirectory = $"{this.environment.WebRootPath}/img/blog-pictures";
            var user = await this.userManager.GetUserAsync(this.User);
            await this.blogServie.CreatPostAsync(input, user.Id, pictureDirectory);

            return this.RedirectToAction(nameof(this.AllPosts));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var editPost = this.blogServie.GetById<EditBlogPostInputmodel>(id);
            return this.View(editPost);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditBlogPostInputmodel input)
        {
            if (!this.ModelState.IsValid
                || !this.stringValidatorService.IsStringValidDecoded(input.Body, GlobalConstants.DefaultBodyStringMinLength))
            {
                var editPost = this.blogServie.GetById<EditBlogPostInputmodel>(id);
                return this.View(editPost);
            }

            string pictureDirectory = $"{this.environment.WebRootPath}/img/blog-pictures";
            await this.blogServie.UpdatePostAsync(id, input, pictureDirectory);
            return this.RedirectToAction(nameof(this.Post), new { id });
        }

        public IActionResult Post(int id)
        {
            var post = this.blogServie.GetById<BlogPostViewModel>(id);
            return this.View(post);
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

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.blogServie.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.AllPosts));
        }
    }
}
