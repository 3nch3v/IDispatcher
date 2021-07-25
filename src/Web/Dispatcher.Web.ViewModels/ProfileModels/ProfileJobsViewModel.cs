namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class ProfileJobsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Job>, IMapFrom<ProfileJobsDto>
    {
    }
}
