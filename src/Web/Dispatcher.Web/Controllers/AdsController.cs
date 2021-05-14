namespace Dispatcher.Web.Controllers
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Mvc;

    public class AdsController : Controller
    {
        private readonly IAdsService adsService;

        public AdsController(IAdsService adsService)
        {
            this.adsService = adsService;
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

        /*
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AdInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.RedirectToAction(nameof(this.All));
        } */
    }
}
