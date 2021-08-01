namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.ProfileModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProfilesController : Controller
    {
        private readonly IProfilesService profileService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(
            IProfilesService profileService,
            UserManager<ApplicationUser> userManager)
        {
            this.profileService = profileService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Profile(string username)
        {
            string userId;

            if (username == null)
            {
                userId = this.userManager.GetUserId(this.User);
            }
            else
            {
                var user = await this.userManager.FindByNameAsync(username);
                userId = user.Id;
            }

            var userDataDto = this.profileService.GetUserById(userId);

            var userProfile = AutoMapperConfig.MapperInstance.Map<ProfileViewModel>(userDataDto);

            return this.View(userProfile);
        }

        [Authorize]
        public async Task<IActionResult> DataManager(string username)
        {
            var loggedInUserId = this.userManager.GetUserId(this.User);

            var user = await this.userManager.FindByNameAsync(username);

            if (user?.Id != loggedInUserId)
            {
                return this.Unauthorized();
            }

            var dataManagerDto = this.profileService.GetUserData(user.Id);

            var dataManager = AutoMapperConfig.MapperInstance.Map<DataManagerViewModel>(dataManagerDto);

            return this.View(dataManager);
        }
    }
}
