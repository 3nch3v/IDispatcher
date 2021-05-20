namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class EditDiscussionViewModel : IMapFrom<Discussion>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int LikesCount { get; set; }

        public bool IsSolved { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
