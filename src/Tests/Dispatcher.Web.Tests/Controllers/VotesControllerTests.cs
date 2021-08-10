namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.VotesModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class VotesControllerTests
    {
        [Theory]
        [InlineData(1, 0)]
        public void VoteShouldReturnObjectWithCommentVotesCount(int expextedLikes, int expectedDislikes)
         => MyController<VotesController>
           .Instance()
           .WithUser()
           .Calling(c => c
                .Vote(GetCommentVote()))
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<HttpPostAttribute>())
           .AndAlso()
           .ShouldReturn()
           .Object(o => o
                .WithModelOfType<VoteResultsModel>(v => v.Likes == expextedLikes
                                                  && v.Dislikes == expectedDislikes));

        [Theory]
        [InlineData(0, 1)]
        public void VoteShouldReturnObjectWithDiscussionVotesCount(int expextedLikes, int expectedDislikes)
       => MyController<VotesController>
         .Instance()
         .WithUser()
         .Calling(c => c
              .Vote(GetDiscussionVote()))
         .ShouldHave()
         .ActionAttributes(a => a
             .ContainingAttributeOfType<AuthorizeAttribute>())
         .AndAlso()
         .ShouldHave()
         .ActionAttributes(a => a
             .ContainingAttributeOfType<HttpPostAttribute>())
         .AndAlso()
         .ShouldReturn()
         .Object(o => o
              .WithModelOfType<VoteResultsModel>(v => v.Likes == expextedLikes
                                                && v.Dislikes == expectedDislikes));

        [Theory]
        [InlineData(0, 0)]
        public void VoteShouldReturnObjectWithWithoutVotesIfDiscussionIdOrCommentIdIsNotValid(int expextedLikes, int expectedDislikes)
         => MyController<VotesController>
           .Instance()
           .WithUser()
           .Calling(c => c
                .Vote(GetInvalidVote()))
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<HttpPostAttribute>())
           .AndAlso()
           .ShouldReturn()
           .Object(o => o
                .WithModelOfType<VoteResultsModel>(v => v.Likes == expextedLikes
                                                  && v.Dislikes == expectedDislikes));
    }
}
