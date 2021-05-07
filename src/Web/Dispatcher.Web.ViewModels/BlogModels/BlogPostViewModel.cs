namespace Dispatcher.Web.ViewModels.BlogModels
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;

    public class BlogPostViewModel : IMapFrom<Blog>
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string PictureUrl { get; set; }

        public string UserId { get; set; }
    }
}
