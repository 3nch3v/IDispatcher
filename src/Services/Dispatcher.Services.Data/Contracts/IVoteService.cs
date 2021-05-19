namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.VotesModels;

    public interface IVoteService
    {
        Task VoteAsync(string userId, int discussionId, string voteType);

        VoteResultsModel GetVoteResults(int discussionId);
    }
}
