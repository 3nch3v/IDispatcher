﻿namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : Controller
    {
        private const string UnsolvedDiscussions = "unsolved";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IForumService forumService;
        private readonly IProfileService profileService;
        private readonly ICommentService commentService;
        private readonly IStringValidatorService stringValidatorService;

        public ForumController(
            UserManager<ApplicationUser> userManager,
            IForumService forumService,
            IProfileService profileService,
            ICommentService commentService,
            IStringValidatorService stringValidatorService)
        {
            this.forumService = forumService;
            this.userManager = userManager;
            this.profileService = profileService;
            this.commentService = commentService;
            this.stringValidatorService = stringValidatorService;
        }

        [Authorize]
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
            if (!this.ModelState.IsValid
                || !this.stringValidatorService.IsStringValidDecoded(input.Description, GlobalConstants.DiscussionDescriptionMinLength))
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

        [Authorize]
        public IActionResult Edit(int id)
        {
            var discussion = this.forumService.GetById<EditDiscussionViewModel>(id);
            var categories = this.forumService.GetCategories<CategoryDropDownViewModel>();
            discussion.Categories = categories;
            return this.View(discussion);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(DiscussionInputModel input, int id)
        {
            if (!this.ModelState.IsValid
                || !this.stringValidatorService.IsStringValidDecoded(input.Description, GlobalConstants.DiscussionDescriptionMinLength))
            {
                var discussion = this.forumService.GetById<EditDiscussionViewModel>(id);
                var categories = this.forumService.GetCategories<CategoryDropDownViewModel>();
                discussion.Categories = categories;
                return this.View(discussion);
            }

            await this.forumService.UpdateAsync<DiscussionInputModel>(input, id);
            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id = id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.forumService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.ForumDiscussions));
        }

        public IActionResult ForumDiscussion(int id)
        {
            var discussion = this.forumService.GetDiscussion(id);
            return this.View(discussion);
        }

        public IActionResult ForumDiscussions(int page = GlobalConstants.DefaultPageNumber)
        {
            var forumDiscussions = new AllForumDiscussionsViewModel
            {
                AllForumDiscussions = this.forumService.GetAllForumDiscussions(page, GlobalConstants.ForumPageEntitiesCount, null),
                ForumDiscussionsCount = this.forumService.ForumDiscussionsCount(),
                Page = page,
            };

            return this.View(forumDiscussions);
        }

        public IActionResult GetDiscussionsPerCategory(string category, int page = GlobalConstants.DefaultPageNumber)
        {
            this.TempData["Category"] = category;

            var forumPosts = new AllForumDiscussionsViewModel
            {
                AllForumDiscussions = this.forumService.GetAllForumDiscussions(page, GlobalConstants.ForumPageEntitiesCount, category),
                ForumDiscussionsCount = this.forumService.GetDiscussionsCountPerCategory(category),
                Page = page,
            };

            return this.View(forumPosts);
        }

        public IActionResult GetUnsolvedDiscussions(int page = GlobalConstants.DefaultPageNumber)
        {
            var unsolvedDiscussions = new AllForumDiscussionsViewModel
            {
                AllForumDiscussions = this.forumService.GetAllForumDiscussions(page, GlobalConstants.ForumPageEntitiesCount, UnsolvedDiscussions),
                ForumDiscussionsCount = this.forumService.GetUnsolvedDiscussionsCount(),
                Page = page,
            };

            return this.View(unsolvedDiscussions);
        }

        [Authorize]
        public async Task<IActionResult> SetToSolved(int id)
        {
            await this.forumService.SetDiscussionToSolvedAsync(id);
            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id = id });
        }

        [Authorize]
        public async Task<IActionResult> Comment(PostInputViewModel input)
        {
            if (!string.IsNullOrWhiteSpace(input.Content))
            {
                var user = await this.userManager.GetUserAsync(this.User);
                input.UserId = user.Id;
                await this.commentService.AddCommentAsync<PostInputViewModel>(input);
            }

            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id = input.DiscussionId });
        }

        [Authorize]
        public async Task<IActionResult> DeleteComment(int id, int discussionId)
        {
            await this.commentService.DeleteCommentAsync(id);
            return this.RedirectToAction(nameof(this.ForumDiscussion), new { id = discussionId });
        }
    }
}
