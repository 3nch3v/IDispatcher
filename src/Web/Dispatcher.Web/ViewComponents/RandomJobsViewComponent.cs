﻿namespace Dispatcher.Web.ViewComponents
{
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.JobModels;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class RandomJobsViewComponent : ViewComponent
    {
        private readonly IJobService jobService;

        public RandomJobsViewComponent(IJobService jobService)
        {
            this.jobService = jobService;
        }

        public IViewComponentResult Invoke()
        {
            var jobs = new RandomJobsModel
            {
                Jobs = this.jobService.GetRandomJobs<SingelRandomJobViewModel>(),
            };

            return this.View(jobs);
        }
    }
}