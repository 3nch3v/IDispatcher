namespace Dispatcher.Web.Controllers
{
    using System.Threading.Tasks;

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

        public IActionResult AllAds()
        {
            var ads = new AllAdsViewModel
            {
                Ads = this.adsService.GetAllAds<AdsViewModel>(),
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

        public IActionResult Edit(int id)
        {
            var ad = this.adsService.GetAd<EditAdViewModel>(id);
            ad.AdTypes = this.adsService.GetAllAdTypes<AdTypesDropDownViewModel>();

            return this.View(ad);
        }

        [HttpPost]
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

        public async Task<IActionResult> Delete(int id)
        {
            await this.adsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.AllAds));
        }
    }
}
