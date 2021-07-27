namespace Dispatcher.Web.ViewModels.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.Forum;

    public class PostInputViewModel : IMapTo<Comment>
    {
        public int DiscussionId { get; set; }

        [Required]
        [StringLength(CommentMaxLenght, MinimumLength = CommentMinLenght)]
        public string Content { get; set; }
    }
}
