namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class ProfileForumDiscussionsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Discussion>, IMapFrom<ProfileForumDiscussionsDto>
    {
    }
}
