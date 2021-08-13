namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.ProjectModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class ProjectsControllerTests : BaseControllerTests
    {
        [Fact]
        public void CreateShouldHaveAuthorizeAttributeAndShouldReturnView()
        => MyController<ProjectsController>
         .Instance()
         .WithUser(u => u.WithIdentifier(UserId))
         .Calling(c => c.Add())
         .ShouldHave()
         .ActionAttributes(a => a
             .ContainingAttributeOfType<AuthorizeAttribute>())
         .AndAlso()
         .ShouldReturn()
         .View();

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldReturnViewWhenModelStateIsNotValid()
           => MyMvc
           .Controller<ProjectsController>(instance => instance
               .WithUser())
           .Calling(c => c.Add(new ProjectInputmodel()))
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
               WithModelOfType<ProjectInputmodel>());

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldRedirectToProfileWhenModelStateIsValid()
         => MyMvc
         .Controller<ProjectsController>(instance => instance
             .WithUser())
         .Calling(c => c.Add(GetValidProjectInputModel()))
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
         .RedirectToAction("Profile");

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnViewWithTheEntityWhenUserHasPermission(int id)
          => MyController<ProjectsController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetProject())
              .Calling(c => c.Edit(id))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .View(v => v
                  .WithModelOfType<EditProjectInputModul>(m => m.Id
                        .ShouldBe(id)));

        [Fact]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserIdNotOwner()
       => MyMvc.Controller<ProjectsController>()
           .WithUser(u => u.WithUsername("Ivan"))
           .WithData(
               GetUserNotOwner(),
               GetProject())
           .Calling(c => c.Edit(1))
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldReturn()
           .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnUnauthorizedWhenUserIdNotOwner(int id)
       => MyController<ProjectsController>
          .Instance()
          .WithUser(u => u.WithUsername("Ivan"))
          .WithData(
              GetUserNotOwner(),
              GetProject())
           .Calling(c => c.Edit(id, new ProjectInputmodel { }))
            .ShouldHave()
            .ActionAttributes(a => a
                .ContainingAttributeOfType<AuthorizeAttribute>())
            .AndAlso()
            .ShouldHave()
            .ActionAttributes(a => a.
                ContainingAttributeOfType<HttpPostAttribute>())
          .AndAlso()
          .ShouldReturn()
          .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnEditViewModelWhenThemodelStateIsInvalid(int id)
        => MyController<ProjectsController>
            .Instance()
            .WithUser(u => u.WithIdentifier(UserId))
            .WithData(
                GetUser(),
                GetProject())
            .Calling(c => c.Edit(id, new EditProjectInputModul { Id = 1 }))
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
                .WithModelOfType<EditProjectInputModul>());

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldRedirectToProfileWhenUserHasPermissionAndModelStateIsValid(int id)
            => MyController<ProjectsController>
               .Instance()
               .WithUser(u => u.WithIdentifier(UserId))
               .WithData(
                   GetUser(),
                   GetProject())
               .Calling(c => c.Edit(id, GetProjectInput()))
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
               .RedirectToAction("Profile");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldRedirectToProfileWhenUserHasPermissions(int id)
         => MyController<ProjectsController>
             .Instance()
             .WithUser(u => u.WithIdentifier(UserId))
             .WithData(
                 GetUser(),
                 GetProject())
             .Calling(c => c.Delete(id))
             .ShouldHave()
             .ActionAttributes(a => a
                 .ContainingAttributeOfType<AuthorizeAttribute>())
             .AndAlso()
             .ShouldReturn()
             .RedirectToAction("Profile");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserHasNoPermissionsToDeleteProject(int id)
           => MyController<ProjectsController>
               .Instance()
               .WithUser()
               .WithData(
                   GetUserNotOwner(),
                   GetProject())
               .Calling(c => c.Delete(id))
               .ShouldHave()
               .ActionAttributes(a => a
                   .ContainingAttributeOfType<AuthorizeAttribute>())
               .AndAlso()
               .ShouldReturn()
               .Unauthorized();

        [Theory]
        [InlineData(23)]
        public void ProjectSchouldReturnErrorWhenTheBlogIdIsNotCorrect(int id)
         => MyMvc.Controller<ProjectsController>()
             .WithData(GetProject())
             .Calling(c => c.Project(id))
             .ShouldReturn()
             .RedirectToAction("Error", "Home");

        [Theory]
        [InlineData(1)]
        public void ProjectchouldReturnViewWithWhenRequestedIdIsCorrect(int id)
            => MyMvc.Controller<ProjectsController>()
                .WithData(GetProject())
                .Calling(c => c.Project(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<SingleProjectViewModel>());
    }
}
