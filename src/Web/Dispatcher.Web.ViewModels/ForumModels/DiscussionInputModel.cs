namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class DiscussionInputModel : IMapTo<Discussion>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(50)]
        [MaxLength(5000)]
        public string Description { get; set; }

        public int LikesCount { get; set; }

        public bool IsSolved { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
