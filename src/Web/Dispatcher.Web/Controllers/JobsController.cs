﻿namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.JobModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class JobsController : Controller
    {
        private readonly IJobService jobService;
        private readonly IStringValidatorService stringValidatorService;
        private readonly UserManager<ApplicationUser> userManager;

        public JobsController(
            IJobService jobService,
            IStringValidatorService stringValidatorService,
            UserManager<ApplicationUser> userManager)
        {
            this.jobService = jobService;
            this.stringValidatorService = stringValidatorService;
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
            if (!this.ModelState.IsValid
                || !this.stringValidatorService.IsStringValidDecoded(input.JobBody, GlobalConstants.DefaultBodyStringMinLength))
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
            var job = this.jobService.GetById<EditJobInputModel>(id);
            return this.View(job);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditJobInputModel input, int id)
        {
            if (!this.ModelState.IsValid
                || !this.stringValidatorService.IsStringValidDecoded(input.JobBody, GlobalConstants.DefaultBodyStringMinLength))
            {
                return this.View(input);
            }

            await this.jobService.UpdateAsync<EditJobInputModel>(input, id);
            return this.RedirectToAction(nameof(this.Job), new { id = id });
        }

        public IActionResult AllJobs(int page = GlobalConstants.DefaultPageNumber)
        {
            var jobs = new AllJobsViewModel
            {
                Jobs = this.jobService.GetAll<SigleJobViewModel>(page, GlobalConstants.JobsPageEntitiesCount),
                Page = page,
                JobsCount = this.jobService.JobsCount(),
            };

            return this.View(jobs);
        }

        public IActionResult Job(int id)
        {
            var job = this.jobService.GetById<SigleJobViewModel>(id);
            return this.View(job);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.jobService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.AllJobs));
        }

        [HttpGet]
        public IActionResult Search(string keyWords, int page = GlobalConstants.DefaultPageNumber)
        {
            if (string.IsNullOrWhiteSpace(keyWords))
            {
                return this.RedirectToAction(nameof(this.AllJobs));
            }

            this.TempData["keyWords"] = keyWords;

            var jobs = new AllJobsViewModel
            {
                Jobs = this.jobService.SearchResults<SigleJobViewModel>(page, GlobalConstants.JobsPageEntitiesCount, keyWords),
                Page = page,
                JobsCount = this.jobService.SearchCount(),
            };

            return this.View(jobs);
        }
    }
}
