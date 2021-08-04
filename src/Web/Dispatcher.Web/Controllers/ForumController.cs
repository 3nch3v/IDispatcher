namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.Infrastructure;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;
    using static Dispatcher.Common.GlobalConstants.Forum;
    using static Dispatcher.Common.GlobalConstants.PageEntities;
    using static Dispatcher.Common.GlobalConstants.User;

    public class ForumController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IForumsService forumService;
        private readonly IProfilesService profileService;
        private readonly ICommentsService commentService;
        private readonly IStringValidatorService stringValidator;

        public ForumController(
            UserManager<ApplicationUser> userManager,
            IForumsService forumService,
            IProfilesService profileService,
            ICommentsService commentService,
            IStringValidatorService stringValidatorService)
        {
            this.forumService = forumService;
            this.userManager = userManager;
            this.profileService = profileService;
            this.commentService = commentService;
            this.stringValidator = stringValidatorService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var discussion = new DiscussionInputModel
            {
                Categories = this.forumService.GetCategories<CategoryDropDownViewModel>(),
            };

            return this.View(discussion);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(DiscussionInputModel input)
        {
            if (!this.stringValidator.IsStringValid(input.Description, DescriptionMinLenght))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var discussionInput = new DiscussionInputModel
                {
                    Categories = this.forumService.GetCategories<CategoryDropDownViewModel>(),
                };

                return this.View(discussionInput);
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.forumService.CreateAsync<DiscussionInputModel>(input, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            var discussion = this.forumService.GetById<EditDiscussionViewModel>(id);

            discussion.Categories = this.forumService.GetCategories<CategoryDropDownViewModel>();

            return this.View(discussion);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(DiscussionInputModel input, int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            if (!this.stringValidator.IsStringValid(input.Description, DescriptionMinLenght))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var discussion = this.forumService.GetById<EditDiscussionViewModel>(id);

                var categories = this.forumService.GetCategories<CategoryDropDownViewModel>();

                discussion.Categories = categories;

                return this.View(discussion);
            }

            await this.forumService.UpdateAsync<DiscussionInputModel>(input, id);

            return this.RedirectToAction(nameof(this.Discussion), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            await this.forumService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Discussion(int id)
        {
            var discussion = this.forumService.GetById<SingleForumDiscussionsViewModel>(id);

            if (discussion == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            return this.View(discussion);
        }

        public IActionResult All(string category = "All", int page = DefaultPageNumber)
        {
            this.TempData["Category"] = category;

            var forumDiscussions = new ForumDiscussionsViewModel
            {
                AllForumDiscussions = this.forumService
                    .GetAllForumDiscussions<SingleForumDiscussionsViewModel>(page, ForumCount, this.TempData["Category"].ToString()),
                ForumDiscussionsCount = this.forumService.GetDiscussionsCount(category),
                Page = page,
            };

            return this.View(forumDiscussions);
        }

        [Authorize]
        public async Task<IActionResult> SetToSolved(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            await this.forumService.SetDiscussionToSolvedAsync(id);

            return this.RedirectToAction(nameof(this.Discussion), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Comment(PostInputViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.userManager.GetUserId(this.User);

                await this.commentService.CreateAsync<PostInputViewModel>(input, userId);
            }

            return this.RedirectToAction(nameof(this.Discussion), new { id = input.DiscussionId });
        }

        [Authorize]
        public async Task<IActionResult> DeleteComment(int id, int discussionId)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            await this.commentService.DeleteAsync(id);

            if (discussionId == default)
            {
                return this.RedirectToAction(nameof(this.All));
            }

            return this.RedirectToAction(nameof(this.Discussion), new { id = discussionId });
        }

        private bool HasPermission(int dataId)
            => PermissionsValidator.HasPermission(
                    this.forumService.GetCreatorId(dataId),
                    this.userManager.GetUserId(this.User),
                    this.User.IsInRole(AdministratorRole));
    }
}
