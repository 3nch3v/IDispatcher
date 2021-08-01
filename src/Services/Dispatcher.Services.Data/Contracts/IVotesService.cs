namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.Dtos;

    public interface IVotesService
    {
        Task VoteDiscussionAsync(string userId, int discussionId, string voteType);

        Task VoteCommensAsync(string userId, int commentId, string voteType);

        VoteResultsDto GetDiscussionVotes(int discussionId);

        VoteResultsDto GetCommentVotes(int commentId);
    }
}
