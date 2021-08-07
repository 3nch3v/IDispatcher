namespace Dispatcher.Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ForumControllerTests
    {
        public ForumControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

        [Fact]
        public void CreateShouldHaveAuthorizeAttributeAndReturnViewWithTheCategories()
           => MyController<ForumController>
            .Instance()
            .WithUser(u => u.WithIdentifier(UserId))
            .WithData(GetCategory())
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
          .Calling(c => c.Create(GetValidInput()))
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
           .Calling(c => c.Edit(GetValidInputModel(), id))
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
          .WithData(GetCategory())
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

        private static IEnumerable<Category> GetCategory()
        {
            return new Category[]
            {
                new Category { Id = 1, Name = "Test" },
                new Category { Id = 2, Name = "Test2" },
                new Category { Id = 3, Name = "Test3" },
            };
        }

        private static DiscussionInputModel GetValidInput()
        {
            return new DiscussionInputModel()
            {
                Title = "Bla bla post",
                CategoryId = 1,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries",
            };
        }

        private static ApplicationUser GetUser()
        {
            return new ApplicationUser
            {
                Id = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                UserName = "Ivan_Dev",
                Email = "ivan@fake.bg",
                PasswordHash = "sdasd324olkk34dff",
            };
        }

        private static Discussion GetDiscussion()
        {
            return new Discussion
            {
                Id = 1,
                CategoryId = 1,
                Title = "Looking for Developers",
                Description = "Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years",
                UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                IsSolved = true,
            };
        }

        private static ApplicationUser GetUserNotOwner()
        {
            return new ApplicationUser
            {
                Id = "TestId",
                UserName = "Ivan",
                Email = "ivan@fake.bg",
                PasswordHash = "sdasd324olkk34dff",
            };
        }

        private static DiscussionInputModel GetValidInputModel()
        {
            return new DiscussionInputModel
            {
                CategoryId = 1,
                Title = "My fake Ad",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
            };
        }

        private static Comment GetComment()
        {
            return new Comment
            {
                Id = 1,
                Content = "Bla bla comment",
                DiscussionId = 1,
                UserId = UserId,
            };
        }
    }
}
