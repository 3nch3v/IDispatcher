namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : Controller
    {
        private readonly IForumService forumService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumController(IForumService forumService, UserManager<ApplicationUser> userManager)
        {
            this.forumService = forumService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var categories = this.forumService.GetCategories<CategoryDropDownViewModel>();
            var discussionInput = new DiscussionInputModel
            {
                Categories = categories,
            };

            return this.View(discussionInput);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(DiscussionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var categories = this.forumService.GetCategories<CategoryDropDownViewModel>();
                var discussionInput = new DiscussionInputModel
                {
                    Categories = categories,
                };

                return this.View(discussionInput);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.forumService.CreateAsync<DiscussionInputModel>(input, user.Id);

            return this.RedirectToAction(nameof(this.ForumDiscussions));
        }

        public IActionResult ForumDiscussions(int page = GlobalConstants.DefaultPageNumber)
        {
            var forumDiscussions = new AllForumDiscussionsViewModel
            {
                AllForumDiscussions = this.forumService.GetAllForumDiscussions<SingleForumDiscussionsViewModel>(page, GlobalConstants.ForumPageEntitiesCount),
                ForumDiscussionsCount = this.forumService.ForumDiscussionsCount(),
                Page = page,
            };

            return this.View(forumDiscussions);
        }

        public IActionResult GetDiscussionsPerCategory(string category, int page = GlobalConstants.DefaultPageNumber)
        {
            var forumPosts = new AllForumDiscussionsViewModel
            {
                AllForumDiscussions = this.forumService.GetAllForumDiscussions<SingleForumDiscussionsViewModel>(page, GlobalConstants.ForumPageEntitiesCount, category),
                ForumDiscussionsCount = this.forumService.ForumDiscussionsPerCategoryCount(),
                Page = page,
            };

            return this.View(forumPosts);
        }

        public IActionResult ForumDiscussion(int id)
        {
            var discussion = this.forumService.GetDiscussion(id);

            return this.View(discussion);
        }

        public async Task<IActionResult> Comment(PostInputViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            input.UserId = user.Id;

            await this.forumService.AddCommentAsync<PostInputViewModel>(input);

            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id = input.DiscussionId });
        }
    }
}
