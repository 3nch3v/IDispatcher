namespace Dispatcher.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class IndexViewModel : IMapFrom<AdminIndexDto>
    {
        public int UsersCount { get; set; }

        public int AdsCount { get; set; }

        public int JobsCount { get; set; }

        public int BlogsCount { get; set; }

        public int DiscussionsCount { get; set; }

        public int CommentsCount { get; set; }

        public int ReviewsCount { get; set; }

        public IEnumerable<string> SearchDataTypes { get; set; }

        public IEnumerable<string> SearchMethodTypes { get; set; }
    }
}
