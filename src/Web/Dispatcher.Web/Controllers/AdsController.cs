namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Dispatcher.Common.GlobalConstants;
    using static Dispatcher.Common.GlobalConstants.Advertisement;
    using static Dispatcher.Common.GlobalConstants.PageEntities;

    public class AdsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAdsService adsService;
        private readonly IStringValidatorService stringValidator;
        private readonly IPermissionsValidatorService permissionsValidator;

        public AdsController(
             UserManager<ApplicationUser> userManager,
             IAdsService adsService,
             IStringValidatorService stringValidator,
             IPermissionsValidatorService permissionsValidator)
        {
            this.adsService = adsService;
            this.stringValidator = stringValidator;
            this.permissionsValidator = permissionsValidator;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var adTypes = this.adsService.GetAllAdTypes<AdTypesViewModel>();
            var adInputModel = new AdInputModel
            {
                AdTypes = adTypes,
            };

            return this.View(adInputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AdInputModel input)
        {
            if (!this.stringValidator.IsStringValidDecoded(input.Description, DescriptionMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var adTypes = this.adsService.GetAllAdTypes<AdTypesViewModel>();
                var adInputModel = new AdInputModel
                {
                    AdTypes = adTypes,
                };

                return this.View(adInputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.adsService.CreateAsync<AdInputModel>(input, user.Id);

            return this.RedirectToAction(nameof(this.AllAds));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            var ad = this.adsService.GetById<EditAdViewModel>(id);
            ad.AdTypes = this.adsService.GetAllAdTypes<AdTypesViewModel>();

            return this.View(ad);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(AdInputModel input, int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            if (!this.stringValidator.IsStringValidDecoded(input.Description, DescriptionMinLength))
            {
                this.ModelState.AddModelError("Error", EmptyBody);
            }

            if (!this.ModelState.IsValid)
            {
                var ad = this.adsService.GetById<EditAdViewModel>(id);
                ad.AdTypes = this.adsService.GetAllAdTypes<AdTypesViewModel>();

                return this.View(ad);
            }

            await this.adsService.UpdateAsync<AdInputModel>(input, id);
            return this.RedirectToAction(nameof(this.Ad), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.HasPermission(id))
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.adsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.AllAds));
        }

        public IActionResult Ad(int id)
        {
            var ad = this.adsService.GetById<AdViewModel>(id);
            return this.View(ad);
        }

        public IActionResult AllAds(int page = DefaultPageNumber)
        {
            var ads = new AllAdsViewModel
            {
                Ads = this.adsService.GetAllAds<AdViewModel>(page, AdsCount),
                AdsCount = this.adsService.AdsCount(),
                Page = page,
            };

            return this.View(ads);
        }

        public IActionResult Search(string keyWords, int page = DefaultPageNumber)
        {
            if (string.IsNullOrWhiteSpace(keyWords))
            {
                return this.RedirectToAction(nameof(this.AllAds));
            }

            this.TempData["KeyWords"] = keyWords;

            var ads = new AllAdsViewModel
            {
                Ads = this.adsService.SearchResults<AdViewModel>(page, AdsCount, this.TempData["KeyWords"].ToString()),
                AdsCount = this.adsService.SearchCount(),
                Page = page,
            };

            return this.View(ads);
        }

        private bool HasPermission(int dataId)
        {
            var hasPermission = this.permissionsValidator.HasPermission(
              this.adsService.GetCreatorId(dataId),
              this.userManager.GetUserId(this.User));

            return hasPermission.Result;
        }
    }
}
