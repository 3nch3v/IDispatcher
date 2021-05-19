namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AdsController : Controller
    {
        private readonly IAdsService adsService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdsController(IAdsService adsService, UserManager<ApplicationUser> userManager)
        {
            this.adsService = adsService;
            this.userManager = userManager;
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
            var ad = this.adsService.GetAd<SingleAdViewModel>(id);

            return this.View(ad);
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
            if (!this.ModelState.IsValid)
            {
                var adTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();
                var adInputModel = new AdInputModel
                {
                    AdTypes = adTypes,
                };

                return this.View(adInputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.adsService.CreateAsync(input, user.Id);

            return this.RedirectToAction(nameof(this.AllAds));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var ad = this.adsService.GetAd<EditAdViewModel>(id);
            ad.AdTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();

            return this.View(ad);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(AdInputModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                var ad = this.adsService.GetAd<EditAdViewModel>(id);
                ad.AdTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();
                return this.View(ad);
            }

            await this.adsService.UpdateAsync(input, id);
            return this.RedirectToAction(nameof(this.AllAds));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.adsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.AllAds));
        }

        ////TODO Paging doesn't work !!! I have to keep the keywords, but how ?????

        [HttpGet]
        public IActionResult Search(string keyWords, int page = GlobalConstants.DefaultPageNumber)
        {
            if (string.IsNullOrWhiteSpace(keyWords))
            {
                return this.RedirectToAction(nameof(this.AllAds));
            }

            this.TempData["keyWords"] = keyWords;

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
