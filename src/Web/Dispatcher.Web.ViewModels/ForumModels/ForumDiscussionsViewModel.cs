namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System;
    using System.Collections.Generic;

    using static Dispatcher.Common.GlobalConstants.PageEntities;

    public class ForumDiscussionsViewModel
    {
        public int ForumDiscussionsCount { get; set; }

        public int PageEntitiesCount => ForumCount;

        public int PagesCount => (int)Math.Ceiling(this.ForumDiscussionsCount * 1.0 / this.PageEntitiesCount);

        public int Page { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public int PreviousPage => this.Page - 1;

        public bool HasNextPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;

        public IEnumerable<SingleForumDiscussionsViewModel> AllForumDiscussions { get; set; }
    }
}
