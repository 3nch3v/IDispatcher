namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Contracts;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AdsController : Controller
    {
        private readonly IAdsService adsService;
        private readonly IStringValidatorService stringValidator;
        private readonly UserManager<ApplicationUser> userManager;

        public AdsController(
            IAdsService adsService,
            IStringValidatorService stringValidator,
            UserManager<ApplicationUser> userManager)
        {
            this.adsService = adsService;
            this.stringValidator = stringValidator;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var adTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();
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
            if (!this.ModelState.IsValid
                || !this.stringValidator.IsStringValidDecoded(input.Description, GlobalConstants.DefaultBodyStringMinLength))
            {
                var adTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();
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
            var ad = this.adsService.GetById<EditAdViewModel>(id);
            ad.AdTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();

            return this.View(ad);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(AdInputModel input, int id)
        {
            if (!this.ModelState.IsValid
                || !this.stringValidator.IsStringValidDecoded(input.Description, GlobalConstants.DefaultBodyStringMinLength))
            {
                var ad = this.adsService.GetById<EditAdViewModel>(id);
                ad.AdTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();
                return this.View(ad);
            }

            await this.adsService.UpdateAsync<AdInputModel>(input, id);
            return this.RedirectToAction(nameof(this.AllAds));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.adsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.AllAds));
        }

        public IActionResult AllAds(int page = GlobalConstants.DefaultPageNumber)
        {
            var ads = new AllAdsViewModel
            {
                Ads = this.adsService.GetAllAds<AdsViewModel>(page, GlobalConstants.AdsPageEntitiesCount),
                AdsCount = this.adsService.AdsCount(),
                Page = page,
            };

            return this.View(ads);
        }

        public IActionResult Ad(int id)
        {
            var ad = this.adsService.GetById<SingleAdViewModel>(id);

            return this.View(ad);
        }

        [HttpGet]
        public IActionResult Search(string keyWords, int page = GlobalConstants.DefaultPageNumber)
        {
            if (string.IsNullOrWhiteSpace(keyWords))
            {
                return this.RedirectToAction(nameof(this.AllAds));
            }

            this.TempData["KeyWords"] = keyWords;

            var ads = new AllAdsViewModel
            {
                Ads = this.adsService.SearchResults<AdsViewModel>(page, GlobalConstants.AdsPageEntitiesCount, this.TempData["KeyWords"].ToString()),
                Page = page,
                AdsCount = this.adsService.SearchCount(),
            };

            return this.View(ads);
        }
    }
}
