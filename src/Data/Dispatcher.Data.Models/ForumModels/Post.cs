namespace Dispatcher.Data.Models.ForumModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Discussion))]
        public int DiscussionId { get; set; }

        public virtual Discussion Discussion { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        public int? LikesCount { get; set; }

        public int? DislikesCount { get; set; }
    }
}
