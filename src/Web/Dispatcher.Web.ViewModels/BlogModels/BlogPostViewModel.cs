namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class BlogPostViewModel : IMapFrom<Blog>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string SanitizedBody => new HtmlSanitizer().Sanitize(this.Body);

        public string ClearBody => WebUtility.HtmlDecode(Regex.Replace(new HtmlSanitizer().Sanitize(this.Body), "<[^>]+>", string.Empty));

        public string PictureFileName { get; set; }

        public string VideoLink { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserUsername { get; set; }
    }
}
