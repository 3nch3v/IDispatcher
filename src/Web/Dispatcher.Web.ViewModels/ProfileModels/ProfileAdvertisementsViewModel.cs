namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class ProfileAdvertisementsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Advertisement>
    {
        public string Description { get; set; }

        public string Compensation { get; set; }
    }
}
