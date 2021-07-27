namespace Dispatcher.Web.ViewModels.BlogModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Blog;

    public class EditBlogPostInputmodel : BlogInputModel, IMapFrom<Blog>, IMapTo<Blog>, IMapTo<BlogPostDto>
    {
        public int Id { get; set; }

        public BlogImage BlogImage { get; set; }

        public string FullFilePath => this.BlogImage == null ? null : $"{BlogPicturePath}/{this.BlogImage.Id}{this.BlogImage.Extension}";
    }
}
