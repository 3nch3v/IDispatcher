namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Forum;

    public class DiscussionInputModel : IMapTo<Discussion>
    {
        [Range(TypeMinRange, TypeMaxRange, ErrorMessage = InvalidCategory)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMAxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }
    }
}
