namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SinglePostViewModel : IMapFrom<Comment>, IMapTo<Comment>
    {
        public int Id { get; set; }

        public string UserUsername { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ProfilePicture { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
