namespace Dispatcher.Web.ViewModels.BlogModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;

    public class EditBlogPostInputmodel : BaseBlogPostInputModel, IMapFrom<Blog>, IMapTo<Blog>
    {
        public int Id { get; set; }

        public string FilePath { get; set; }
    }
}
