namespace Dispatcher.Web.ViewModels.BlogModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class EditBlogPostInputmodel : BlogInputModel, IMapFrom<Blog>, IMapTo<Blog>, IMapTo<BlogPostDto>
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public string Extension { get; set; }

        public string FullFilePath => $"{this.FilePath}{this.Extension}";
    }
}
