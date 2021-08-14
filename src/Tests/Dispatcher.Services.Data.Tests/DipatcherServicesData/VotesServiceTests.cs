namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Threading.Tasks;

    using Xunit;

    public class VotesServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task VoteDiscussionAsyncShoulIncreaseTheLikesProperlyForAGivenDiscussionId()
        {
            var service = GetVotesService(DiscussionsVotesRepository);

            await service.VoteDiscussionAsync(UserId, 1, "Like");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task VoteDiscussionAsyncShoulIncreaseTheDislikesProperlyForAGivenDiscussionId()
        {
            var service = GetVotesService(DiscussionsVotesRepository);

            await service.VoteDiscussionAsync(UserId, 1, "Dislike");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(2, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserCanNotVoteTwoTimesWithTheSameVoteForAGivenDiscussionId()
        {
            var service = GetVotesService(DiscussionsVotesRepository);

            await service.VoteDiscussionAsync(UserId, 1, "Like");
            await service.VoteDiscussionAsync(UserId, 1, "Like");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserMayChangeTheVoteForAGivenDiscussionIdAndTheVotesShouldBeIncreasedAndDecreasedProperly()
        {
            var service = GetVotesService(DiscussionsVotesRepository);

            await service.VoteDiscussionAsync(UserId, 1, "Like");
            await service.VoteDiscussionAsync(UserId, 1, "Dislike");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(2, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserMayChangeTheVoteForAGivenDiscussionIdFromDislikeToLikeAndTheVotesShouldBeIncreasedAndDecreasedProperly()
        {
            var service = GetVotesService(DiscussionsVotesRepository);

            await service.VoteDiscussionAsync(UserId, 1, "Dislike");
            await service.VoteDiscussionAsync(UserId, 1, "Like");
            var actualVoteResult = service.GetDiscussionVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task VoteCommentAsyncShoulIncreaseTheLikesProperlyForAGivenCommentId()
        {
            var service = GetVotesService(null, CommentVotesRepository);

            await service.VoteCommensAsync(UserId, 1, "Like");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(0, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task VoteCommentAsyncShoulIncreaseTheDislikesProperlyForAGivenCommentId()
        {
            var service = GetVotesService(null, CommentVotesRepository);

            await service.VoteCommensAsync(UserId, 1, "Dislike");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserCanNotVoteTwoTimesWithTheSameVoteForAGivenCommentId()
        {
            var service = GetVotesService(null, CommentVotesRepository);

            await service.VoteCommensAsync(UserId, 1, "Like");
            await service.VoteCommensAsync(UserId, 1, "Like");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(0, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserMayChangeTheVoteForAGivenCommentIdAndTheVotesShouldBeIncreasedAndDecreasedProperly()
        {
            var service = GetVotesService(null, CommentVotesRepository);

            await service.VoteCommensAsync(UserId, 1, "Like");
            await service.VoteCommensAsync(UserId, 1, "Dislike");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(2, actualVoteResult.Likes);
            Assert.Equal(1, actualVoteResult.Dislikes);
        }

        [Fact]
        public async Task UserMayChangeTheVoteForAGivenCommentIdAndTheLikeVotesShouldBeIncreasedAndDislikesDecreasedProperly()
        {
            var service = GetVotesService(null, CommentVotesRepository);

            await service.VoteCommensAsync(UserId, 1, "Dislike");
            await service.VoteCommensAsync(UserId, 1, "Like");
            var actualVoteResult = service.GetCommentVotes(1);

            Assert.Equal(3, actualVoteResult.Likes);
            Assert.Equal(0, actualVoteResult.Dislikes);
        }
    }
}
