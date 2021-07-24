namespace Dispatcher.Web.ViewModels.BlogModels
{
    using System;
    using System.Collections.Generic;

    using static Dispatcher.Common.GlobalConstants.PageEntities;

    public class AllBlogPostsViewModel
    {
        public int BlogPostsCount { get; set; }

        public int PageEntitiesCount => BlogsCount;

        public int PagesCount => (int)Math.Ceiling(this.BlogPostsCount * 1.0 / this.PageEntitiesCount);

        public int Page { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public int PreviousPage => this.Page - 1;

        public bool HasNextPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;

        public IEnumerable<BlogPostViewModel> Posts { get; set; }
    }
}
