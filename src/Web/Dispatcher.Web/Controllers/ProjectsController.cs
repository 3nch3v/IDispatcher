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
            var projects = new AllProjectsViewModel
            {
                Projects = this.projectServices.GetAllProjects<SingleProjectViewModel>(),
            };

            return this.View(projects);  ////TODO use it into User Profile
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

        public async Task<IActionResult> Delete(int id)
        {
            await this.projectServices.Delete(id);
            return this.RedirectToAction(nameof(this.AllProjects)); ////TODO redicetc to User Profile
        }
    }
}
