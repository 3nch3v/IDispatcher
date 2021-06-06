namespace Dispatcher.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Common;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Data.Dtos;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> votes;

        public VoteService(IRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public async Task VoteAsync(string userId, int discussionId, string voteType)
        {
            var vote = this.votes.All().FirstOrDefault(x => x.DiscussionId == discussionId && x.UserId == userId);

            if (vote is null)
            {
                vote = new Vote
                {
                    DiscussionId = discussionId,
                    UserId = userId,
                    Like = voteType == GlobalConstants.Like ? 1 : default,
                    Dislike = voteType == GlobalConstants.Dislike ? 1 : default,
                };

                await this.votes.AddAsync(vote);
            }
            else
            {
                if (vote.Like == 1 && voteType == GlobalConstants.Dislike)
                {
                    vote.Like -= 1;
                    vote.Dislike += 1;
                }
                else if (vote.Dislike == 1 && voteType == GlobalConstants.Like)
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
                .All()
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
