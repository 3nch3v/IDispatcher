namespace Dispatcher.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;
    using static Dispatcher.Common.GlobalConstants.Forum;
    using static Dispatcher.Common.GlobalConstants.PageEntities;

    public class ForumController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IForumService forumService;
        private readonly IProfileService profileService;
        private readonly ICommentService commentService;
        private readonly IStringValidatorService stringValidator;
        private readonly IPermissionsValidatorService permissionsValidator;

        public ForumController(
            UserManager<ApplicationUser> userManager,
            IForumService forumService,
            IProfileService profileService,
            ICommentService commentService,
            IStringValidatorService stringValidatorService,
            IPermissionsValidatorService permissionsValidator)
        {
            this.forumService = forumService;
            this.userManager = userManager;
            this.profileService = profileService;
            this.commentService = commentService;
            this.stringValidator = stringValidatorService;
            this.permissionsValidator = permissionsValidator;
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
            if (!this.stringValidator.IsStringValidDecoded(input.Description, DescriptionMinLenght))
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

            return this.RedirectToAction(nameof(this.ForumDiscussions));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
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
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.stringValidator.IsStringValidDecoded(input.Description, DescriptionMinLenght))
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
            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.forumService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.ForumDiscussions));
        }

        public IActionResult ForumDiscussion(int id)
        {
            var discussion = this.forumService.GetById<SingleForumDiscussionsViewModel>(id);
            discussion.ProfilePicture = this.profileService.GetProfilePicturePath(discussion.UserId);
            discussion.Posts.ToList().ForEach(x => x.ProfilePicture = this.profileService.GetProfilePicturePath(x.UserId));

            return this.View(discussion);
        }

        public IActionResult ForumDiscussions(string category = "All", int page = DefaultPageNumber)
        {
            this.TempData["Category"] = category;

            var forumDiscussions = new ForumDiscussionsViewModel
            {
                AllForumDiscussions = this.forumService.GetAllForumDiscussions<SingleForumDiscussionsViewModel>(page, ForumCount, this.TempData["Category"].ToString()),
                ForumDiscussionsCount = this.forumService.GetDiscussionsCount(category),
                Page = page,
            };

            forumDiscussions.AllForumDiscussions.ToList()
                .ForEach(x => x.ProfilePicture = this.profileService.GetProfilePicturePath(x.UserId));

            return this.View(forumDiscussions);
        }

        [Authorize]
        public async Task<IActionResult> SetToSolved(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.forumService.SetDiscussionToSolvedAsync(id);

            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Comment(PostInputViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.userManager.GetUserId(this.User);
                input.UserId = userId;
                await this.commentService.CreateAsync<PostInputViewModel>(input);
            }

            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id = input.DiscussionId });
        }

        [Authorize]
        public async Task<IActionResult> DeleteComment(int id, int discussionId)
        {
            var hasPermission = this.permissionsValidator.HasPermission(
              this.commentService.GetCreatorId(id),
              this.userManager.GetUserId(this.User));

            if (!hasPermission.Result)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.commentService.DeleteAsync(id);

            if (discussionId == default)
            {
                return this.RedirectToAction(nameof(this.ForumDiscussions));
            }

            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id = discussionId });
        }

        private bool HasPermission(int dataId)
        {
            var hasPermission = this.permissionsValidator.HasPermission(
              this.forumService.GetCreatorId(dataId),
              this.userManager.GetUserId(this.User));

            return hasPermission.Result;
        }
    }
}
