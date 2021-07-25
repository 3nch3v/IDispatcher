namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class ProfileBlogsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Blog>, IMapFrom<ProfileBlogDtos>
    {
    }
}
