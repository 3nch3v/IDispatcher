namespace Dispatcher.Web.Tests.Controllers
{
    using System.Reflection;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.JobModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class JobsControllerTests
    {
        public JobsControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

        [Fact]
        public void CreateShouldHaveAuthorizeAttributeAndReturnViewWithTheAdTypes()
          => MyController<JobsController>
           .Instance()
           .WithUser(u => u.WithIdentifier(UserId))
           .WithoutData()
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
            .Controller<JobsController>(instance => instance
                .WithUser())
            .Calling(c => c.Create(new JobInputModel()))
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
                WithModelOfType<JobInputModel>());

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldRedirectToAllWhenModelStateIsValid()
         => MyMvc
         .Controller<JobsController>(instance => instance
             .WithUser())
         .Calling(c => c.Create(GetValidInputModel()))
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
          => MyController<JobsController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetJob())
              .Calling(c => c.Edit(id))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .View(v => v
                  .WithModelOfType<EditJobInputModel>(m => m.Id == id));

        [Fact]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserIdNotOwner()
          => MyMvc.Controller<JobsController>()
              .WithUser(u => u.WithUsername("Ivan"))
              .WithData(
                  GetUserNotOwner(),
                  GetJob())
              .Calling(c => c.Edit(1))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnkEditViewWhenThemodelStateIsInvalid(int id)
           => MyController<JobsController>
               .Instance()
               .WithUser(u => u.WithIdentifier(UserId))
               .WithData(
                   GetUser(),
                   GetJob())
               .Calling(c => c.Edit(new EditJobInputModel { Id = id }))
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
                   .WithModelOfType<EditJobInputModel>(m => m.Id == id));

        [Fact]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldRedirectToTheJobWhenUserHasPermissionAndModelStateIsValid()
         => MyController<JobsController>
             .Instance()
             .WithUser(u => u.WithIdentifier(UserId))
             .WithData(
                 GetUser(),
                 GetJob())
             .Calling(c => c.Edit(GetEditInputModel()))
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
             .RedirectToAction("Job");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldRedirectToAllWhenUserHasPermissions(int id)
          => MyController<JobsController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetJob())
              .Calling(c => c.Delete(id))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldReturn()
              .RedirectToAction("All");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserHasNoPermissionsToDeleteJob(int id)
           => MyController<AdsController>
               .Instance()
               .WithUser()
               .WithData(
                   GetUserNotOwner(),
                   GetJob())
               .Calling(c => c.Delete(id))
               .ShouldHave()
               .ActionAttributes(a => a
                   .ContainingAttributeOfType<AuthorizeAttribute>())
               .AndAlso()
               .ShouldReturn()
               .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void JobSchouldReturnErrorWhenTheJobIdIsNotCorrectOrMissing(int id)
           => MyMvc.Controller<JobsController>()
               .WithoutData()
               .Calling(c => c.Job(id))
               .ShouldReturn()
               .RedirectToAction("Error", "Home");

        [Fact]
        public void AllSchouldReturnViewWithTheDefaultEntitiesCountPerPage()
           => MyMvc.Controller<JobsController>()
               .WithData(GetJob())
               .Calling(c => c.All(1))
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<AllJobsViewModel>());

        [Fact]
        public void SearchShouldRedirectToAllWhenSearchTermIsNull()
        => MyMvc.Controller<JobsController>()
              .WithData(GetJob())
              .Calling(c => c.Search(null, 1))
              .ShouldReturn()
              .RedirectToAction("All");

        [Theory]
        [InlineData("Id", 1)]
        public void SearchShouldReturnViewWithJobsWhenSearchTermIsValid(string searchTerm, int id)
             => MyMvc.Controller<JobsController>()
                   .WithData(GetJob())
                   .Calling(c => c.Search(searchTerm, id))
                   .ShouldHave()
                   .TempData(t => t.Equals(searchTerm))
                   .AndAlso()
                   .ShouldReturn()
                   .View(v => v
                        .WithModelOfType<AllJobsViewModel>());

        private static JobInputModel GetValidInputModel()
        {
            return new JobInputModel
            {
                Title = "Test",
                JobBody = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                CompanyName = "Hacker GmbH",
                Location = "Paris",
                Contact = "0121490458342",
            };
        }

        private static EditJobInputModel GetEditInputModel()
        {
            return new EditJobInputModel
            {
                Id = 1,
                Title = "Test",
                JobBody = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                CompanyName = "Hacker GmbH",
                Location = "Paris",
                Contact = "0121490458342",
            };
        }

        private static Job GetJob()
        {
            return new Job
            {
                Id = 1,
                Title = "Test",
                JobBody = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                CompanyName = "Hacker GmbH",
                Location = "Paris",
                Contact = "0121490458342",
                UserId = UserId,
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
