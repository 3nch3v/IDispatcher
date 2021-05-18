namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System;
    using System.Collections.Generic;

    using Dispatcher.Common;

    public class AllForumDiscussionsViewModel
    {
        public IEnumerable<SingleForumDiscussionsViewModel> AllForumDiscussions { get; set; }

        public int ForumDiscussionsCount { get; set; }

        public int PageEntitiesCount => GlobalConstants.ForumPageEntitiesCount;

        public int PagesCount => (int)Math.Ceiling(this.ForumDiscussionsCount * 1.0 / this.PageEntitiesCount);

        public int Page { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public int PreviousPage => this.Page - 1;

        public bool HasNextPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;
    }
}
