namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersReviewsController : Controller
    {
        private readonly IProfileService profileServices;
        private readonly UserManager<ApplicationUser> userManager;

        public CustomersReviewsController(
            IProfileService profileServices,
            UserManager<ApplicationUser> userManager)
        {
            this.profileServices = profileServices;
            this.userManager = userManager;
        }

        public IActionResult All(string id)
        {
            var comments = new AllCommentsViewModel
            {
                Comments = this.profileServices.GetComments<CommentViewModel>(id),
                UserId = id,
            };

            return this.View(comments);
        }

        [Authorize]
        public async Task<IActionResult> Comment(CommentInputModel input, string userId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.All), new { id = userId });
            }

            var loggedInUserId = this.userManager.GetUserId(this.User);

            if (!string.IsNullOrWhiteSpace(input.Comment) && loggedInUserId != userId)
            {
                input.UserId = userId;
                await this.profileServices.CommentAsync<CommentInputModel>(loggedInUserId, input);
            }

            return this.RedirectToAction(nameof(this.All), new { id = userId });
        }
    }
}
