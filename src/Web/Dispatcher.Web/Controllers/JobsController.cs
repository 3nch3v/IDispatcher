namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.JobModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class JobsController : Controller
    {
        private readonly IJobService jobService;
        private readonly UserManager<ApplicationUser> userManager;

        public JobsController(
            IJobService jobService,
            UserManager<ApplicationUser> userManager)
        {
            this.jobService = jobService;
            this.userManager = userManager;
        }

        public IActionResult AllJobs()
        {
            var jobs = new AllJobsViewModel
            {
                Jobs = this.jobService.GetAllAsync<SigleJobViewModel>(),
            };

            return this.View(jobs);
        }

        public IActionResult Job(int id)
        {
            var job = this.jobService.GetJob<SigleJobViewModel>(id);
            return this.View(job);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.jobService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.AllJobs));
        }

        [Authorize]
        public async Task<IActionResult> Create(JobInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.jobService.CreateAsync(input, user.Id);

            return this.RedirectToAction(nameof(this.AllJobs));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var job = this.jobService.GetJob<EditJobInputModel>(id);
            return this.View(job);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditJobInputModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.jobService.UpdateAsync(input, id);
            return this.RedirectToAction(nameof(this.Job), new { id });
        }
    }
}
