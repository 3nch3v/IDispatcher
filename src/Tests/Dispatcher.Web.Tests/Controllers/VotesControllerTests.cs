namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.VotesModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class VotesControllerTests
    {
        [Fact]
        public void VoteShouldReturnObjectWithCommentVotesCount()
         => MyController<VotesController>
           .Instance()
           .WithUser()
           .Calling(c => c
                .Vote(new VoteInputModel() { CommentId = 1, VoteType = "Like" }))
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
                .WithModelOfType<VoteResultsModel>(v => v.Likes == 1
                                                && v.Dislikes == 0));

        [Fact]
        public void VoteShouldReturnObjectWithDiscussionVotesCount()
       => MyController<VotesController>
         .Instance()
         .WithUser()
         .Calling(c => c
              .Vote(new VoteInputModel() { DiscussionId = 1, VoteType = "Dislike" }))
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
              .WithModelOfType<VoteResultsModel>(v => v.Likes == 0
                                              && v.Dislikes == 1));

        [Fact]
        public void VoteShouldReturnObjectWithWithoutVotesIfDiscussionIdOrCommentIdIsNotValid()
         => MyController<VotesController>
           .Instance()
           .WithUser()
           .Calling(c => c
                .Vote(new VoteInputModel() { VoteType = "Dislike" }))
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
                .WithModelOfType<VoteResultsModel>(v => v.Likes == 0
                                             && v.Dislikes == 0));
    }
}
