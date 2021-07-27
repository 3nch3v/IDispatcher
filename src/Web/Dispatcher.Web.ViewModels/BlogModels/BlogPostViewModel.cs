namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    using static Dispatcher.Common.GlobalConstants.Blog;

    public class BlogPostViewModel : IMapFrom<Blog>, IMapFrom<BlogImage>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string SanitizedBody => new HtmlSanitizer().Sanitize(this.Body);

        public string ClearBody => WebUtility.HtmlDecode(Regex.Replace(new HtmlSanitizer().Sanitize(this.Body), "<[^>]+>", string.Empty));

        public BlogImage BlogImage { get; set; }

        public string FullFilePath => this.BlogImage == null ? null : $"{BlogPicturePath}/{this.BlogImage.Id}{this.BlogImage.Extension}";

        public string YouTubeVideoId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserUsername { get; set; }

        public string UserId { get; set; }
    }
}
