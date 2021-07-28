namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;
    using static Dispatcher.Common.GlobalConstants.Blog;
    using static Dispatcher.Common.GlobalConstants.PageEntities;

    public class BlogsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogService blogServie;
        private readonly IWebHostEnvironment environment;
        private readonly IStringValidatorService stringValidator;
        private readonly IPermissionsValidatorService permissionsValidator;

        public BlogsController(
            UserManager<ApplicationUser> userManager,
            IBlogService blogServie,
            IWebHostEnvironment environment,
            IStringValidatorService stringValidator,
            IPermissionsValidatorService permissionsValidator)
        {
            this.blogServie = blogServie;
            this.userManager = userManager;
            this.environment = environment;
            this.stringValidator = stringValidator;
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
            if (!this.stringValidator.IsStringValidDecoded(input.Body, BodyMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string pictureDirectory = $"{this.environment.WebRootPath}{BlogPicturePath}";

            var userId = this.userManager.GetUserId(this.User);

            await this.blogServie.CreateAsync<BlogInputModel>(input, userId, pictureDirectory);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
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
                return this.Unauthorized();
            }

            if (!this.stringValidator.IsStringValidDecoded(input.Body, BodyMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var editPost = this.blogServie.GetById<EditBlogPostInputmodel>(id);

                return this.View(editPost);
            }

            string pictureDirectory = $"{this.environment.WebRootPath}{BlogPicturePath}";

            await this.blogServie.UpdateAsync<EditBlogPostInputmodel>(input, id, pictureDirectory);

            return this.RedirectToAction(nameof(this.Post), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            await this.blogServie.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Post(int id)
        {
            var post = this.blogServie.GetById<BlogPostViewModel>(id);

            return this.View(post);
        }

        public IActionResult All(int page = DefaultPageNumber)
        {
            var posts = new AllBlogPostsViewModel()
            {
                Posts = this.blogServie.GetAllBlogPosts<BlogPostViewModel>(page, BlogsCount),
                Page = page,
                BlogPostsCount = this.blogServie.BlogPostsCount(),
            };

            return this.View(posts);
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
