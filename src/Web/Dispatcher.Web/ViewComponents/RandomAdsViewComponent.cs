namespace Dispatcher.Web.ViewComponents
{
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class RandomAdsViewComponent : ViewComponent
    {
        private readonly IAdsService adServices;

        public RandomAdsViewComponent(IAdsService adServices)
        {
            this.adServices = adServices;
        }

        public IViewComponentResult Invoke(int adsCount)
        {
            var ads = new RandomAdsModel
            {
                Ads = this.adServices.RandomAds<SigleRandomAdViewModel>(adsCount),
            };

            return this.View(ads);
        }
    }
}
