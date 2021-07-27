namespace Dispatcher.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Data.Contracts;

    using static Dispatcher.Common.GlobalConstants.Forum;

    public class VoteService : IVoteService
    {
        private readonly IRepository<DiscussionVote> votes;

        public VoteService(IRepository<DiscussionVote> votes)
        {
            this.votes = votes;
        }

        public async Task VoteAsync(string userId, int discussionId, string voteType)
        {
            var vote = this.votes.All().FirstOrDefault(x => x.DiscussionId == discussionId && x.UserId == userId);

            if (vote is null)
            {
                vote = new DiscussionVote
                {
                    DiscussionId = discussionId,
                    UserId = userId,
                    Like = voteType == Like ? 1 : default,
                    Dislike = voteType == Dislike ? 1 : default,
                };

                await this.votes.AddAsync(vote);
            }
            else
            {
                if (vote.Like == 1 && voteType == Dislike)
                {
                    vote.Like -= 1;
                    vote.Dislike += 1;
                }
                else if (vote.Dislike == 1 && voteType == Like)
                {
                    vote.Like += 1;
                    vote.Dislike -= 1;
                }
            }

            await this.votes.SaveChangesAsync();
        }

        public VoteResultsDto GetVoteResults(int discussionId)
        {
            var votes = this.votes
                .AllAsNoTracking()
                .Where(x => x.DiscussionId == discussionId)
                .Select(x => new
                {
                    Likes = x.Like,
                    Dislikes = x.Dislike,
                })
                .ToList();

            var results = new VoteResultsDto
            {
                Likes = votes.Sum(x => x.Likes),
                Dislikes = votes.Sum(x => x.Dislikes),
            };

            return results;
        }
    }
}
