namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.JobModels;
    using Microsoft.AspNetCore.Mvc;

    public class JobsController : Controller
    {
        private readonly IJobService jobService;

        public JobsController(IJobService jobService)
        {
            this.jobService = jobService;
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
    }
}
