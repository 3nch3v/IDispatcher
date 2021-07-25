namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class ProfileAdvertisementsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Advertisement>, IMapFrom<ProfileAdvertisementsDto>
    {
        public string Compensation { get; set; }
    }
}
