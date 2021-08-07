namespace Dispatcher.Web.Tests.Controllers
{
    using System.Reflection;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.ProjectModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProjectsControllerTests
    {
        public ProjectsControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

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
         .Calling(c => c.Add(GetValidInputModel()))
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
                  .WithModelOfType<EditProjectInputModul>(m => m.Id == id));

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
        public void ProjectchouldReturnTheAdWithTheCalledIdWhenTheAdIdIsCorrect(int id)
            => MyMvc.Controller<ProjectsController>()
                .WithData(GetProject())
                .Calling(c => c.Project(id))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<SingleProjectViewModel>());

        private static ProjectInputmodel GetValidInputModel()
        {
            return new ProjectInputmodel
            {
                Name = "Test Prject",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                UserRole = "Boss",
            };
        }

        private static Project GetProject()
        {
            return new Project
            {
                Id = 1,
                Name = "Test Prject",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                UserRole = "Boss",
                UserId = UserId,
            };
        }

        private static ProjectInputmodel GetProjectInput()
        {
            return new ProjectInputmodel
            {
                Name = "Test Prject",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ",
                UserRole = "Boss",
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
    }
}
