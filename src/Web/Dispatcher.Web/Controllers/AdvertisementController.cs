namespace Dispatcher.Web.Controllers
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Mvc;

    public class AdvertisementController : Controller
    {
        private readonly IAdService adsService;

        public AdvertisementController(IAdService adsService)
        {
            this.adsService = adsService;
        }

        public IActionResult AllAds()
        {
            var ads = new AllAdsViewModel
            {
                Ads = this.adsService.GetAllAds<SingleAdViewModel>(),
            };

            return this.View();
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
