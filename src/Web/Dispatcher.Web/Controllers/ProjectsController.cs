namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ProjectModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectServices;
        private readonly IPermissionsValidatorService permissionsValidator;

        public ProjectsController(
            UserManager<ApplicationUser> userManager,
            IProjectService projectServices,
            IPermissionsValidatorService permissionsValidator)
        {
            this.projectServices = projectServices;
            this.permissionsValidator = permissionsValidator;
            this.userManager = userManager;
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
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.projectServices.CreateAsync<ProjectInputmodel>(input, userId);

            return this.RedirectToAction(nameof(ProfilesController.Profile), "Profiles");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            var project = this.projectServices.GetById<EditProjectInputModul>(id);

            return this.View(project);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProjectInputmodel input)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                var project = this.projectServices.GetById<EditProjectInputModul>(id);

                return this.View(project);
            }

            await this.projectServices.UpdateAsync<ProjectInputmodel>(input, id);

            return this.RedirectToAction(nameof(ProfilesController.Profile), "Profiles");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            await this.projectServices.DeleteAsync(id);

            return this.RedirectToAction(nameof(ProfilesController.Profile), "Profiles");
        }

        public IActionResult Project(int id)
        {
            var project = this.projectServices.GetById<SingleProjectViewModel>(id);

            return this.View(project);
        }

        private bool HasPermission(int dataId)
        {
            var hasPermission = this.permissionsValidator.HasPermission(
                this.projectServices.GetCreatorId(dataId),
                this.userManager.GetUserId(this.User));

            return hasPermission.Result;
        }
    }
}
