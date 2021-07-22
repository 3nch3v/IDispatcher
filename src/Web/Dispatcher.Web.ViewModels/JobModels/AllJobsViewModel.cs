namespace Dispatcher.Web.ViewModels.JobModels
{
    using System;
    using System.Collections.Generic;

    using static Dispatcher.Common.GlobalConstants;

    public class AllJobsViewModel
    {
        public IEnumerable<SigleJobViewModel> Jobs { get; set; }

        public int JobsCount { get; set; }

        public int PageEntitiesCount => PageEntities.JobsCount;

        public int PagesCount => (int)Math.Ceiling(this.JobsCount * 1.0 / this.PageEntitiesCount);

        public int Page { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public int PreviousPage => this.Page - 1;

        public bool HasNextPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;
    }
}
