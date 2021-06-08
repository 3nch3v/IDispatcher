namespace Dispatcher.Services.Data.Dtos
{
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class ProfileForumDiscussionsDto : BaseProfileCollectionsDto, IMapFrom<Discussion>
    {
    }
}
