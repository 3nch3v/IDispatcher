namespace Dispatcher.Web.Controllers
{
    using AutoMapper;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProfilesController : Controller
    {
        private readonly IProfileService profileService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(
            IProfileService profileService,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            this.profileService = profileService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Profile(string userId)
        {
            if (userId == null)
            {
                userId = this.userManager.GetUserId(this.User);
            }

            var userDataDto = this.profileService.GetUserById(userId);
            var userProfile = this.mapper.Map<ProfileViewModel>(userDataDto);

            return this.View(userProfile);
        }

        [Authorize]
        public IActionResult DataManager(string userId)
        {
            var loggedInUserId = this.userManager.GetUserId(this.User);

            if (userId != loggedInUserId)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var dataManagerDto = this.profileService.GetUserData(userId);
            var dataManager = this.mapper.Map<DataManagerViewModel>(dataManagerDto);

            return this.View(dataManager);
        }
    }
}
