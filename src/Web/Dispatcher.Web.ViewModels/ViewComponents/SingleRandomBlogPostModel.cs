namespace Dispatcher.Web.ViewModels.ViewComponents
{
    using System.Net;
    using System.Text.RegularExpressions;

    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SingleRandomBlogPostModel : IMapFrom<Blog>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string SanitizedBody => new HtmlSanitizer().Sanitize(this.Body);

        public string ClearBody => WebUtility.HtmlDecode(Regex.Replace(this.SanitizedBody, "<[^>]+>", string.Empty));

        public string FilePath { get; set; }

        public bool IsWithPicture { get; set; }
}
}
