﻿namespace Dispatcher.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<string> SearchData { get; set; }

        public IEnumerable<string> SearchMethod { get; set; }

        public string SearchTerm { get; set; }

        public int UsersCount { get; set; }

        public int AdsCount { get; set; }

        public int JobsCount { get; set; }

        public int BlogsCount { get; set; }

        public int DiscussionsCount { get; set; }

        public int CommentsCount { get; set; }

        public int ReviewsCount { get; set; }
    }
}
