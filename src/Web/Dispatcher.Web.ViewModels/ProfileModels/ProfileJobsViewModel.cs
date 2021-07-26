namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Services.Mapping;

    public class ProfileJobsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Job>, IMapFrom<ProfileJobsDto>
    {
    }
}
