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

    using static Dispatcher.Common.GlobalConstants.Blog;
    using static Dispatcher.Common.GlobalConstants.PageEntities;

    public class BlogsController : Controller
    {
        private readonly IBlogService blogServie;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;
        private readonly IStringValidatorService stringValidatorService;
        private readonly IPermissionsValidatorService permissionsValidator;

        public BlogsController(
            UserManager<ApplicationUser> userManager,
            IBlogService blogServie,
            IWebHostEnvironment environment,
            IStringValidatorService stringValidatorService,
            IPermissionsValidatorService permissionsValidator)
        {
            this.blogServie = blogServie;
            this.userManager = userManager;
            this.environment = environment;
            this.stringValidatorService = stringValidatorService;
            this.permissionsValidator = permissionsValidator;
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
                || !this.stringValidatorService.IsStringValidDecoded(input.Body, BodyMinLength))
            {
                return this.View();
            }

            string pictureDirectory = $"{this.environment.WebRootPath}{BlogPicturePath}";
            input.PictureDirectory = pictureDirectory;
            var user = await this.userManager.GetUserAsync(this.User);
            await this.blogServie.CreateAsync<BlogInputModel>(input, user.Id);

            return this.RedirectToAction(nameof(this.AllPosts));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            var editPost = this.blogServie.GetById<EditBlogPostInputmodel>(id);
            return this.View(editPost);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditBlogPostInputmodel input)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.ModelState.IsValid
                || !this.stringValidatorService.IsStringValidDecoded(input.Body, BodyMinLength))
            {
                var editPost = this.blogServie.GetById<EditBlogPostInputmodel>(id);
                return this.View(editPost);
            }

            string pictureDirectory = $"{this.environment.WebRootPath}{BlogPicturePath}";
            input.PictureDirectory = pictureDirectory;
            await this.blogServie.UpdateAsync<EditBlogPostInputmodel>(input, id);
            return this.RedirectToAction(nameof(this.Post), new { id });
        }

        public IActionResult Post(int id)
        {
            var post = this.blogServie.GetById<BlogPostViewModel>(id);
            return this.View(post);
        }

        public IActionResult AllPosts(int page = DefaultPageNumber)
        {
            var posts = new AllBlogPostsViewModel()
            {
                Posts = this.blogServie.GetAllBlogPosts<BlogPostViewModel>(page, BlogsCount),
                Page = page,
                BlogPostsCount = this.blogServie.BlogPostsCount(),
            };

            return this.View(posts);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.blogServie.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.AllPosts));
        }

        private bool HasPermission(int dataId)
        {
            var hasPermission = this.permissionsValidator.HasPermission(
              this.blogServie.GetCreatorId(dataId),
              this.userManager.GetUserId(this.User));

            return hasPermission.Result;
        }
    }
}
