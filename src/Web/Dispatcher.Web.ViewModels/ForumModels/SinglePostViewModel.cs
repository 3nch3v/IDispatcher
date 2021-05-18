namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SinglePostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string UserUsername { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public int LikesCount { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
