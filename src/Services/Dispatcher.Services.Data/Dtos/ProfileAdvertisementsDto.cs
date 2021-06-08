namespace Dispatcher.Services.Data.Dtos
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class ProfileAdvertisementsDto : BaseProfileCollectionsDto, IMapFrom<Advertisement>
    {
        public string Description { get; set; }

        public string Compensation { get; set; }
    }
}
