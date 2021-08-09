namespace Dispatcher.Web.Tests.Controllers
{
    using System.Linq;

    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class ForumControllerTests : BaseControllerTests
    {
        [Fact]
        public void CreateShouldHaveAuthorizeAttributeAndReturnViewWithTheCategories()
           => MyController<ForumController>
            .Instance()
            .WithUser(u => u.WithIdentifier(UserId))
            .WithData(GetForumCategory())
            .Calling(c => c.Create())
            .ShouldHave()
            .ActionAttributes(a => a
                .ContainingAttributeOfType<AuthorizeAttribute>())
            .AndAlso()
            .ShouldReturn()
            .View(view => view
                .WithModelOfType<DiscussionInputModel>(v => v
                .Categories.Count() == 3
                 && v.Categories.First().Name == "Test"));

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldReturnViewWhenModelStateIsInvalid()
          => MyMvc
          .Controller<ForumController>(instance => instance
              .WithUser())
          .Calling(c => c.Create(new DiscussionInputModel()))
          .ShouldHave()
          .ActionAttributes(a => a
             .ContainingAttributeOfType<AuthorizeAttribute>())
          .AndAlso()
          .ShouldHave()
          .ActionAttributes(a => a.
              ContainingAttributeOfType<HttpPostAttribute>())
          .AndAlso()
          .ShouldHave()
          .InvalidModelState()
          .AndAlso()
          .ShouldReturn()
          .View(view => view.
              WithModelOfType<DiscussionInputModel>());

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldRedirectToAllWhenModelStateIsValid()
          => MyMvc
          .Controller<ForumController>(instance => instance
              .WithUser())
          .Calling(c => c.Create(GetValidDiscussionInput()))
          .ShouldHave()
          .ActionAttributes(a => a
              .ContainingAttributeOfType<AuthorizeAttribute>())
          .AndAlso()
          .ShouldHave()
          .ActionAttributes(a => a.
              ContainingAttributeOfType<HttpPostAttribute>())
          .AndAlso()
          .ShouldHave()
          .ValidModelState()
          .AndAlso()
          .ShouldReturn()
          .RedirectToAction("All");

        [Fact]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserIdNotOwner()
          => MyMvc.Controller<ForumController>()
              .WithUser(u => u.WithUsername("Ivan"))
              .WithData(
                  GetUserNotOwner(),
                  GetDiscussion())
              .Calling(c => c.Edit(1))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnViewWithTheEntityWhenUserHasPermission(int id)
          => MyController<ForumController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetDiscussion())
              .Calling(c => c.Edit(id))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .View(v => v
                  .WithModelOfType<EditDiscussionViewModel>(m => m.Id == id));

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnInputViewWhenThemodelStateIsInvalid(int id)
            => MyController<ForumController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetDiscussion())
                .Calling(c => c.Edit(new DiscussionInputModel { }, id))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldHave()
                .ActionAttributes(a => a.
                    ContainingAttributeOfType<HttpPostAttribute>())
               .AndAlso()
               .ShouldHave()
               .InvalidModelState()
               .AndAlso()
               .ShouldReturn()
               .View(v => v
                   .WithModelOfType<EditDiscussionViewModel>(m => m.Id == id));

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldRedirectToTheDiscussionWhenUserHasPermissionAndModelStateIsValid(int id)
       => MyController<ForumController>
           .Instance()
           .WithUser(u => u.WithIdentifier(UserId))
           .WithData(
               GetUser(),
               GetDiscussion())
           .Calling(c => c.Edit(GetValidDiscussionInput(), id))
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldHave()
           .ActionAttributes(a => a.
                 ContainingAttributeOfType<HttpPostAttribute>())
           .AndAlso()
           .ShouldHave()
           .ValidModelState()
           .AndAlso()
           .ShouldReturn()
           .RedirectToAction("Discussion");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldRedirectToAllWhenUserHasPermissions(int id)
          => MyController<ForumController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetDiscussion())
              .Calling(c => c.Delete(id))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .RedirectToAction("All");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserHasNoPermissionsToDeleteDiscussion(int id)
          => MyController<ForumController>
              .Instance()
              .WithUser()
              .WithData(
                  GetUserNotOwner(),
                  GetDiscussion())
              .Calling(c => c.Delete(id))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .Unauthorized();

        [Fact]
        public void SetToSolvedShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserIdNotOwner()
        => MyMvc.Controller<ForumController>()
            .WithUser(u => u.WithUsername("Ivan"))
            .WithData(
                GetUserNotOwner(),
                GetDiscussion())
            .Calling(c => c.SetToSolved(1))
            .ShouldHave()
            .ActionAttributes(a => a
                .ContainingAttributeOfType<AuthorizeAttribute>())
            .AndAlso()
            .ShouldReturn()
            .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void SetToSolvedShouldHaveAuthorizeAttributeAndShouldRedirectToTheGivenDiscussionWhenUserHasPermission(int id)
            => MyController<ForumController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetDiscussion())
                .Calling(c => c.SetToSolved(id))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
               .RedirectToAction("Discussion");

        [Fact]
        public void CommentShouldHaveAuthorizeAttributeAndRedirectToTheCurrentDiscussion()
         => MyController<ForumController>
          .Instance()
          .WithUser(u => u.WithIdentifier(UserId))
          .WithData(GetForumCategory())
          .Calling(c => c.Comment(new PostInputViewModel { Content = "Bla bla", DiscussionId = 1, }))
          .ShouldHave()
          .ActionAttributes(a => a
              .ContainingAttributeOfType<AuthorizeAttribute>())
          .AndAlso()
          .ShouldReturn()
          .RedirectToAction("Discussion");

        [Theory]
        [InlineData(1)]
        public void DeleteCommentShouldHaveAuthorizeAttributeAndShouldRedirectToTheCurrentDiscussionWhenUserHasPermissions(int id)
        => MyController<ForumController>
            .Instance()
            .WithUser(u => u.WithIdentifier(UserId))
            .WithData(
                GetUser(),
                GetDiscussion(),
                GetComment())
            .Calling(c => c.DeleteComment(id, id))
            .ShouldHave()
            .ActionAttributes(a => a
                .ContainingAttributeOfType<AuthorizeAttribute>())
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("Discussion");

        [Theory]
        [InlineData(1)]
        public void DeleteCommentShouldHaveAuthorizeAttributeAndShouldRedirectToDiscussionWhenSuccess(int id)
            => MyController<ForumController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetComment())
                .Calling(c => c.DeleteComment(id, id))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Discussion");

        [Theory]
        [InlineData(1)]
        public void DeleteCommentShouldHaveAuthorizeAttributeAndShouldRedirectToAllDiscussionsWhenDiscussionIdIsNotValid(int id)
           => MyController<ForumController>
               .Instance()
               .WithUser(u => u.WithIdentifier(UserId))
               .WithData(
                   GetUser(),
                   GetComment())
               .Calling(c => c.DeleteComment(id, default))
               .ShouldHave()
               .ActionAttributes(a => a
                   .ContainingAttributeOfType<AuthorizeAttribute>())
               .AndAlso()
               .ShouldReturn()
               .RedirectToAction("All");
    }
}
