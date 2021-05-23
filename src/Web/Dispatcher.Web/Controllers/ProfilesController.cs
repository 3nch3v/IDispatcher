namespace Dispatcher.Web.Controllers
{
    using Dispatcher.Services.Data.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProfilesController : Controller
    {
        private readonly IProfileService profileService;

        public ProfilesController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [Authorize]
        public IActionResult Profile()
        {
            return this.View();
        }
    }
}
