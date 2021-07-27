namespace Dispatcher.Web.ViewModels.VotesModels
{
    public class VoteInputModel
    {
        public int DiscussionId { get; set; }

        public int CommentId { get; set; }

        public string VoteType { get; set; }
    }
}
