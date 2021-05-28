namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class PostInputViewModel : IMapTo<Comment>
    {
        public int DiscussionId { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 2)]
        public string Content { get; set; }
    }
}
