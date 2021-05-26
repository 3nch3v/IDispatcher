namespace Dispatcher.Web.Controllers
{
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProfilesController : Controller
    {
        private readonly IProfileService profileService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public ProfilesController(
            IProfileService profileService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.profileService = profileService;
            this.userManager = userManager;
            this.environment = environment;
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
