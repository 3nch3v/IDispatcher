namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.Infrastructure;
    using Dispatcher.Web.ViewModels.JobModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;
    using static Dispatcher.Common.GlobalConstants.Job;
    using static Dispatcher.Common.GlobalConstants.PageEntities;
    using static Dispatcher.Common.GlobalConstants.User;

    public class JobsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJobsService jobService;
        private readonly IStringValidatorService stringValidator;

        public JobsController(
            UserManager<ApplicationUser> userManager,
            IJobsService jobService,
            IStringValidatorService stringValidatorService)
        {
            this.jobService = jobService;
            this.stringValidator = stringValidatorService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(JobInputModel input)
        {
            if (!this.stringValidator.IsStringValid(input.JobBody, BodyMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.jobService.CreateAsync(input, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            var job = this.jobService.GetById<EditJobInputModel>(id);

            return this.View(job);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditJobInputModel input)
        {
            if (!this.HasPermission(input.Id))
            {
                return this.Unauthorized();
            }

            if (!this.stringValidator.IsStringValid(input.JobBody, BodyMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.jobService.UpdateAsync<EditJobInputModel>(input, input.Id);

            return this.RedirectToAction(nameof(this.Job), new { input.Id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            await this.jobService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All(int page = DefaultPageNumber)
        {
            var jobs = new AllJobsViewModel
            {
                Jobs = this.jobService.GetAll<SigleJobViewModel>(page, JobsCount),
                Page = page,
                JobsCount = this.jobService.JobsCount(),
            };

            return this.View(jobs);
        }

        [HttpGet]
        public IActionResult Search(string keyWords, int page = DefaultPageNumber)
        {
            if (string.IsNullOrWhiteSpace(keyWords))
            {
                return this.RedirectToAction(nameof(this.All));
            }

            this.TempData["keyWords"] = keyWords;

            var jobs = new AllJobsViewModel
            {
                Jobs = this.jobService.SearchResults<SigleJobViewModel>(page, JobsCount, keyWords),
                Page = page,
                JobsCount = this.jobService.SearchCount(),
            };

            return this.View(jobs);
        }

        public IActionResult Job(int id)
        {
            var job = this.jobService.GetById<SigleJobViewModel>(id);

            if (job == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            return this.View(job);
        }

        private bool HasPermission(int dataId)
             => PermissionsValidator.HasPermission(
                     this.jobService.GetCreatorId(dataId),
                     this.userManager.GetUserId(this.User),
                     this.User.IsInRole(AdministratorRole));
    }
}
