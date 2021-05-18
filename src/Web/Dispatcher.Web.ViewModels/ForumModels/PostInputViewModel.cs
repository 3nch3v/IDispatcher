namespace Dispatcher.Web.ViewModels.ForumModels
{
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;

    public class PostInputViewModel : IMapTo<Post>
    {
        public int DiscussionId { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
