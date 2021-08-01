namespace Dispatcher.Web.ViewComponents
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class RandomJobsViewComponent : ViewComponent
    {
        private readonly IJobsService jobService;

        public RandomJobsViewComponent(IJobsService jobService)
        {
            this.jobService = jobService;
        }

        public IViewComponentResult Invoke()
        {
            var jobs = new RandomJobsModel
            {
                Jobs = this.jobService.GetRandomJobs<SingelRandomJobViewModel>(3),
            };

            return this.View(jobs);
        }
    }
}
