namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;

    public class ProfileBlogsViewModel : BaseProfileCollectionsViewModel, IMapFrom<Blog>
    {
    }
}
