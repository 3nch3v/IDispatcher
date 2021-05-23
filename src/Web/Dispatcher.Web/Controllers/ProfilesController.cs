namespace Dispatcher.Web.Controllers
{
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProfilesController : Controller
    {
        private readonly IProfileService profileService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(
            IProfileService profileService,
            UserManager<ApplicationUser> userManager)
        {
            this.profileService = profileService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Profile(string userId)
        {
            string id = userId;

            if (userId == null)
            {
                id = this.userManager.GetUserId(this.User);
            }

            var userProfile = this.profileService.GetUserById<ProfileViewModel>(id);
            return this.View(userProfile);
        }
    }
}
