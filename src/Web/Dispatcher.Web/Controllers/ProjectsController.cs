namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ProjectModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : Controller
    {
        private readonly IProjectService projectServices;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectsController(
            IProjectService projectServices,
            UserManager<ApplicationUser> userManager)
        {
            this.projectServices = projectServices;
            this.userManager = userManager;
        }

        public IActionResult AllProjects()
        {
            ////TODO
            return this.View();
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(ProjectInputmodel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.projectServices.AddProjectAsync(input, user.Id);

            return this.RedirectToAction(nameof(this.AllProjects)); ////TODO redicetc to User Profile
        }
    }
}
