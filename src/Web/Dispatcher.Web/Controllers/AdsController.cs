namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.Infrastructure;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;
    using static Dispatcher.Common.GlobalConstants.Advertisement;
    using static Dispatcher.Common.GlobalConstants.PageEntities;
    using static Dispatcher.Common.GlobalConstants.User;

    public class AdsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAdsService adsService;
        private readonly IStringValidatorService stringValidator;

        public AdsController(
             UserManager<ApplicationUser> userManager,
             IAdsService adsService,
             IStringValidatorService stringValidator)
        {
            this.adsService = adsService;
            this.stringValidator = stringValidator;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var input = new AdvertisementInputModel
            {
                AdvertisementTypes = this.adsService.GetAllAdTypes<AdvertisementTypeViewModel>(),
            };

            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AdvertisementInputModel input)
        {
            if (!this.stringValidator.IsStringValid(input.Description, DescriptionMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var invalidInput = new AdvertisementInputModel
                {
                    AdvertisementTypes = this.adsService.GetAllAdTypes<AdvertisementTypeViewModel>(),
                };

                return this.View(invalidInput);
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.adsService.CreateAsync<AdvertisementInputModel>(input, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            var ad = this.adsService.GetById<EditAdvertisementViewModel>(id);

            ad.AdvertisementTypes = this.adsService.GetAllAdTypes<AdvertisementTypeViewModel>();

            return this.View(ad);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(AdvertisementInputModel input, int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            if (!this.stringValidator.IsStringValid(input.Description, DescriptionMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var ad = this.adsService.GetById<EditAdvertisementViewModel>(id);

                ad.AdvertisementTypes = this.adsService.GetAllAdTypes<AdvertisementTypeViewModel>();

                return this.View(ad);
            }

            await this.adsService.UpdateAsync<AdvertisementInputModel>(input, id);

            return this.RedirectToAction(nameof(this.Ad), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.Unauthorized();
            }

            await this.adsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Ad(int id)
        {
            var ad = this.adsService.GetById<AdvertisementViewModel>(id);

            if (ad == null)
            {
                return this.RedirectToAction("Error", "Home");
            }

            return this.View(ad);
        }

        public IActionResult All(int page = DefaultPageNumber)
        {
            var ads = new AllAdvertisementsViewModel
            {
                Advertisements = this.adsService.GetAll<AdvertisementViewModel>(page, AdsCount),
                AdvertisementsCount = this.adsService.AdsCount(),
                Page = page,
            };

            return this.View(ads);
        }

        public IActionResult Search(string keyWords, int page = DefaultPageNumber)
        {
            if (string.IsNullOrWhiteSpace(keyWords))
            {
                return this.RedirectToAction(nameof(this.All));
            }

            this.TempData["KeyWords"] = keyWords;

            var ads = new AllAdvertisementsViewModel
            {
                Advertisements = this.adsService.SearchResult<AdvertisementViewModel>(page, AdsCount, this.TempData["KeyWords"].ToString()),
                AdvertisementsCount = this.adsService.SearchCount(),
                Page = page,
            };

            return this.View(ads);
        }

        private bool HasPermission(int dataId)
            => PermissionsValidator.HasPermission(
                    this.adsService.GetCreatorId(dataId),
                    this.userManager.GetUserId(this.User),
                    this.User.IsInRole(AdministratorRole));
    }
}
