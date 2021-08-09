namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class BlogsControllerTests : BaseControllerTests
    {
        [Fact]
        public void CreateShouldHaveAuthorizeAttributeAndShouldReturnView()
          => MyController<BlogsController>
           .Instance()
           .WithUser(u => u.WithIdentifier(UserId))
           .Calling(c => c.Create())
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldReturn()
           .View();

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldReturnViewWhenModelStateIsInvalid()
           => MyMvc
           .Controller<BlogsController>(instance => instance
               .WithUser())
           .Calling(c => c.Create(new BlogInputModel()))
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
               WithModelOfType<BlogInputModel>());

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldRedirectToAllWhenModelStateIsValid()
          => MyMvc
          .Controller<BlogsController>(instance => instance
              .WithUser())
          .Calling(c => c.Create(GetValidBlogInputModel()))
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

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnViewWithTheEntityWhenUserHasPermission(int id)
           => MyController<BlogsController>
               .Instance()
               .WithUser(u => u.WithIdentifier(UserId))
               .WithData(
                   GetUser(),
                   GetBlog())
               .Calling(c => c.Edit(id))
               .ShouldHave()
               .ActionAttributes(a => a
                   .ContainingAttributeOfType<AuthorizeAttribute>())
               .AndAlso()
               .ShouldReturn()
               .View(v => v
                   .WithModelOfType<EditBlogPostInputmodel>(m => m.Id == id));

        [Fact]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserIdNotOwner()
          => MyMvc.Controller<BlogsController>()
              .WithUser(u => u.WithUsername("Ivan"))
              .WithData(
                  GetUserNotOwner(),
                  GetBlog())
              .Calling(c => c.Edit(1))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .Unauthorized();

        [Fact]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnInputViewWhenThemodelStateIsInvalid()
           => MyController<BlogsController>
               .Instance()
               .WithUser(u => u.WithIdentifier(UserId))
               .WithData(
                   GetUser(),
                   GetBlog())
               .Calling(c => c.Edit(new EditBlogPostInputmodel { Id = 1 }))
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
                   .WithModelOfType<EditBlogPostInputmodel>());

        [Fact]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldRedirectToTheBlogWhenUserHasPermissionAndModelStateIsValid()
             => MyController<BlogsController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetBlog())
                .Calling(c => c.Edit(GetEditBlogInputmodel()))
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
                .RedirectToAction("Post");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldRedirectToAllWhenUserHasPermissions(int id)
          => MyController<BlogsController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetBlog())
              .Calling(c => c.Delete(id))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .RedirectToAction("All");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserHasNoPermissionsToDeleteBlog(int id)
           => MyController<AdsController>
               .Instance()
               .WithUser()
               .WithData(
                   GetUserNotOwner(),
                   GetBlog())
               .Calling(c => c.Delete(id))
               .ShouldHave()
               .ActionAttributes(a => a
                   .ContainingAttributeOfType<AuthorizeAttribute>())
               .AndAlso()
               .ShouldReturn()
               .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void BlogSchouldReturnErrorWhenTheBlogIdIsNotCorrectOrMissing(int id)
           => MyMvc.Controller<AdsController>()
               .WithoutData()
               .Calling(c => c.Ad(id))
               .ShouldReturn()
               .RedirectToAction("Error", "Home");

        [Theory]
        [InlineData(23)]
        public void BlogSchouldReturnErrorWhenTheBlogIdIsNotCorrect(int id)
           => MyMvc.Controller<BlogsController>()
               .WithData(GetBlog())
               .Calling(c => c.Post(id))
               .ShouldReturn()
               .RedirectToAction("Error", "Home");

        [Fact]
        public void AllSchouldReturnViewWithDiscussionEntities()
            => MyMvc.Controller<BlogsController>()
                .WithData(GetBlog())
                .Calling(c => c.All(1))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AllBlogPostsViewModel>());
    }
}
