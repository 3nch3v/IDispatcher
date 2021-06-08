namespace Dispatcher.Services.Data.Dtos
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class ProfileJobsDto : BaseProfileCollectionsDto, IMapFrom<Job>
    {
    }
}
