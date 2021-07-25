namespace Dispatcher.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.Dtos;

    public interface IVoteService
    {
        Task VoteAsync(string userId, int discussionId, string voteType);

        VoteResultsDto GetVoteResults(int discussionId);
    }
}
