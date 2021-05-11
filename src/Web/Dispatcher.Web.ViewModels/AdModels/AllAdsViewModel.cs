namespace Dispatcher.Web.ViewModels.AdModels
{
    using System.Collections.Generic;

    public class AllAdsViewModel
    {
        public IEnumerable<SingleAdViewModel> Ads { get; set; }
    }
}
