namespace Dispatcher.Web.ViewModels.BlogModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class BlogInputModel : BaseBlogPostInputModel, IMapTo<Blog>, IMapTo<BlogPostDto>
    {
    }
}
