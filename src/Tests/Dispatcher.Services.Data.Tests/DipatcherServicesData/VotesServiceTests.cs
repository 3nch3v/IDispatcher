namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task VoteDiscussionAsyncShoulIncreaseTheLikesProperlyForAGivenDiscussionId()
        {
            var service = this.GetService(this.GetDiscussionsVotesRepository());

            await service.VoteDiscussionAsync(this.GetUserId(), 1, "Like");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task VoteDiscussionAsyncShoulIncreaseTheDislikesProperlyForAGivenDiscussionId()
        {
            var service = this.GetService(this.GetDiscussionsVotesRepository());

            await service.VoteDiscussionAsync(this.GetUserId(), 1, "Dislike");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(2, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserCanNotVoteTwoTimesWithTheSameVoteForAGivenDiscussionId()
        {
            var service = this.GetService(this.GetDiscussionsVotesRepository());

            await service.VoteDiscussionAsync(this.GetUserId(), 1, "Like");
            await service.VoteDiscussionAsync(this.GetUserId(), 1, "Like");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserMayChangeTheVoteForAGivenDiscussionIdAndTheVotesShouldBeIncreasedAndDecreasedProperly()
        {
            var service = this.GetService(this.GetDiscussionsVotesRepository());

            await service.VoteDiscussionAsync(this.GetUserId(), 1, "Like");
            await service.VoteDiscussionAsync(this.GetUserId(), 1, "Dislike");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(2, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task VoteCommentAsyncShoulIncreaseTheLikesProperlyForAGivenCommentId()
        {
            var service = this.GetService(null, this.GetCommentVotesRepository());

            await service.VoteCommensAsync(this.GetUserId(), 1, "Like");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(0, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task VoteCommentAsyncShoulIncreaseTheDislikesProperlyForAGivenCommentId()
        {
            var service = this.GetService(null, this.GetCommentVotesRepository());

            await service.VoteCommensAsync(this.GetUserId(), 1, "Dislike");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserCanNotVoteTwoTimesWithTheSameVoteForAGivenCommentId()
        {
            var service = this.GetService(null, this.GetCommentVotesRepository());

            await service.VoteCommensAsync(this.GetUserId(), 1, "Like");
            await service.VoteCommensAsync(this.GetUserId(), 1, "Like");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(0, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserMayChangeTheVoteForAGivenCommentIdAndTheVotesShouldBeIncreasedAndDecreasedProperly()
        {
            var service = this.GetService(null, this.GetCommentVotesRepository());

            await service.VoteCommensAsync(this.GetUserId(), 1, "Like");
            await service.VoteCommensAsync(this.GetUserId(), 1, "Dislike");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        private IVotesService GetService(
            IRepository<DiscussionVote> discussionsVotes = null,
            IRepository<CommentVote> commentsVotes = null)
        {
            var service = new VotesService(discussionsVotes, commentsVotes);

            return service;
        }

        private EfRepository<DiscussionVote> GetDiscussionsVotesRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfRepository<DiscussionVote>(dbContext);

            return repository;
        }

        private EfRepository<CommentVote> GetCommentVotesRepository()
        {
            var dbContext = this.PrepareDb().Result;
            var repository = new EfRepository<CommentVote>(dbContext);

            return repository;
        }

        private async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            data.DiscussionVotes.Add(new DiscussionVote()
            {
                Id = 1,
                DiscussionId = 1,
                Like = 1,
                UserId = Guid.NewGuid().ToString(),
            });
            data.DiscussionVotes.Add(new DiscussionVote()
            {
                Id = 2,
                DiscussionId = 1,
                Like = 1,
                UserId = Guid.NewGuid().ToString(),
            });
            data.DiscussionVotes.Add(new DiscussionVote()
            {
                Id = 3,
                DiscussionId = 1,
                Dislike = 1,
                UserId = Guid.NewGuid().ToString(),
            });
            data.DiscussionVotes.Add(new DiscussionVote()
            {
                Id = 4,
                DiscussionId = 2,
                Dislike = 1,
                UserId = Guid.NewGuid().ToString(),
            });

            data.CommentVotes.Add(new CommentVote()
            {
                Id = 1,
                CommentId = 1,
                Like = 1,
                UserId = Guid.NewGuid().ToString(),
            });
            data.CommentVotes.Add(new CommentVote()
            {
                Id = 2,
                CommentId = 1,
                Like = 1,
                UserId = Guid.NewGuid().ToString(),
            });
            data.CommentVotes.Add(new CommentVote()
            {
                Id = 3,
                CommentId = 2,
                Dislike = 1,
                UserId = Guid.NewGuid().ToString(),
            });
            data.CommentVotes.Add(new CommentVote()
            {
                Id = 4,
                CommentId = 2,
                Dislike = 1,
                UserId = Guid.NewGuid().ToString(),
            });

            await data.SaveChangesAsync();

            return data;
        }

        private string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }
    }
}
