namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class EditDiscussionViewModel : IMapFrom<Discussion>
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
