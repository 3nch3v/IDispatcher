namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class ProfileJobsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Job>
    {
    }
}
