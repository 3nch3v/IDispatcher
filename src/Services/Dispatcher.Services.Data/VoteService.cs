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
        private readonly IRepository<DiscussionVote> discussionsVotes;
        private readonly IRepository<CommentVote> commentsVotes;

        public VoteService(
            IRepository<DiscussionVote> discussionsVotes,
            IRepository<CommentVote> commentsVotes)
        {
            this.discussionsVotes = discussionsVotes;
            this.commentsVotes = commentsVotes;
        }

        public async Task VoteDiscussionAsync(string userId, int discussionId, string voteType)
        {
            var vote = this.discussionsVotes.All().FirstOrDefault(x => x.DiscussionId == discussionId && x.UserId == userId);

            if (vote is null)
            {
                vote = new DiscussionVote
                {
                    DiscussionId = discussionId,
                    UserId = userId,
                    Like = voteType == Like ? 1 : default,
                    Dislike = voteType == Dislike ? 1 : default,
                };

                await this.discussionsVotes.AddAsync(vote);
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

            await this.discussionsVotes.SaveChangesAsync();
        }

        public async Task VoteCommensAsync(string userId, int commentId, string voteType)
        {
            var vote = this.commentsVotes.All().FirstOrDefault(x => x.CommentId == commentId && x.UserId == userId);

            if (vote is null)
            {
                vote = new CommentVote
                {
                    CommentId = commentId,
                    UserId = userId,
                    Like = voteType == Like ? 1 : default,
                    Dislike = voteType == Dislike ? 1 : default,
                };

                await this.commentsVotes.AddAsync(vote);
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

            await this.discussionsVotes.SaveChangesAsync();
        }

        public VoteResultsDto GetDiscussionVotes(int discussionId)
        {
            var votes = this.discussionsVotes
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

        public VoteResultsDto GetCommentVotes(int commentId)
        {
            var votes = this.commentsVotes
                .AllAsNoTracking()
                .Where(x => x.CommentId == commentId)
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
