namespace Dispatcher.Web.ViewModels.ViewComponents
{
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SingleRandomBlogPostModel : IMapFrom<Blog>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string SanitizedBody => new HtmlSanitizer().Sanitize(this.Body);

        public string RemotePictureUrl { get; set; }

        public bool IsWithPicture { get; set; }
}
}
