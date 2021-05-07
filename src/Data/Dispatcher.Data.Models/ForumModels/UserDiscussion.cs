namespace Dispatcher.Data.Models.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserDiscussion
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int DiscussionId { get; set; }

        public virtual Discussion Discussion { get; set; }
    }
}
