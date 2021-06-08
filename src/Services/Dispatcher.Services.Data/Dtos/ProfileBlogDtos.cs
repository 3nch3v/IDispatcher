namespace Dispatcher.Services.Data.Dtos
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;

    public class ProfileBlogDtos : BaseProfileCollectionsDto, IMapFrom<Blog>
    {
    }
}
