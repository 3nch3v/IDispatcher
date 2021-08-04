namespace Dispatcher.Web.Controllers
{
    using System.IO;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.Infrastructure;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;
    using static Dispatcher.Common.GlobalConstants.Blog;
    using static Dispatcher.Common.GlobalConstants.PageEntities;
    using static Dispatcher.Common.GlobalConstants.User;

    public class BlogsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogsService blogServie;
        private readonly IWebHostEnvironment environment;
        private readonly IStringValidatorService stringValidator;

        public BlogsController(
            UserManager<ApplicationUser> userManager,
            IBlogsService blogServie,
            IWebHostEnvironment environment,
            IStringValidatorService stringValidator)
        {
            this.blogServie = blogServie;
            this.userManager = userManager;
            this.environment = environment;
            this.stringValidator = stringValidator;
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
            if (!this.stringValidator.IsStringValid(input.Body, BodyMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            byte[] picture = await input.Picture.GetBytes();

            string picturePath = $"{this.environment.WebRootPath}{BlogPicturePath}";

            string pictureExtension = Path.GetExtension(input.Picture.FileName);

            var userId = this.userManager.GetUserId(this.User);

            await this.blogServie.CreateAsync<BlogInputModel>(input, userId, picture, picturePath, pictureExtension);

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
        public async Task<IActionResult> Edit(int blogId, EditBlogPostInputmodel input)
        {
            if (!this.HasPermission(blogId))
            {
                return this.Unauthorized();
            }

            if (!this.stringValidator.IsStringValid(input.Body, BodyMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var editPost = this.blogServie.GetById<EditBlogPostInputmodel>(blogId);

                return this.View(editPost);
            }

            byte[] picture = await input.Picture.GetBytes();

            string picturePath = $"{this.environment.WebRootPath}{BlogPicturePath}";

            string pictureExtension = Path.GetExtension(input.Picture.FileName);

            await this.blogServie.UpdateAsync<EditBlogPostInputmodel>(input, blogId, picture, picturePath, pictureExtension);

            return this.RedirectToAction(nameof(this.Post), new { blogId });
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

            if (post == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

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
            => PermissionsValidator.HasPermission(
                    this.blogServie.GetCreatorId(dataId),
                    this.userManager.GetUserId(this.User),
                    this.User.IsInRole(AdministratorRole));
    }
}
