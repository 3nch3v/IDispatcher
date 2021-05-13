namespace Dispatcher.Web.ViewModels.BlogModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;

    public class BlogInputModel : BaseBlogPostInputModel, IMapTo<Blog>
    {
        public string UserId { get; set; }
    }
}
