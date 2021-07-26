namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class EditDiscussionViewModel : DiscussionInputModel, IMapFrom<Discussion>
    {
        [Required]
        public int Id { get; set; }
    }
}
