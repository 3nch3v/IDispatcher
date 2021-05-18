namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System;
    using System.Collections.Generic;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SingleForumDiscussionsViewModel : IMapFrom<Discussion>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public int LikesCount { get; set; }

        public bool IsSolved { get; set; }

        public string CategoryName { get; set; }

        public string UserId { get; set; }

        public string UserUsername { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual IEnumerable<SinglePostViewModel> Posts { get; set; }
    }
}
