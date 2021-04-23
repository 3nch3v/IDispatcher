namespace Dispatcher.Data.Models.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserDiscussion
    {
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int DiscussionId { get; set; }

        public virtual Discussion Discussion { get; set; }
    }
}
