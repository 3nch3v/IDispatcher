namespace Dispatcher.Web.Tests.Controllers
{
    using System.Linq;

    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.JobModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class JobsControllerTests : BaseControllerTests
    {
        [Fact]
        public void CreateShouldHaveAuthorizeAttributeAndReturnView()
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
         .Calling(c => c.Create(GetValidJobInputModel()))
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
                  .WithModelOfType<EditJobInputModel>(m => m.Id
                        .ShouldBe(id)));

        [Fact]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserIdNotOwner()
          => MyMvc.Controller<JobsController>()
              .WithUser()
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

        [Fact]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnUnauthorizedWhenUserIdNotOwner()
            => MyController<JobsController>
               .Instance()
               .WithUser(u => u.WithUsername("Ivan"))
               .WithData(
                   GetUserNotOwner(),
                   GetProject())
                .Calling(c => c.Edit(new EditJobInputModel { }))
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
                   .WithModelOfType<EditJobInputModel>(m => m.Id
                        .ShouldBe(id)));

        [Fact]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldRedirectToTheJobWhenUserHasPermissionAndModelStateIsValid()
         => MyController<JobsController>
             .Instance()
             .WithUser(u => u.WithIdentifier(UserId))
             .WithData(
                 GetUser(),
                 GetJob())
             .Calling(c => c.Edit(GetJobEditInputModel()))
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
             .RedirectToAction("Job", new { GetJobEditInputModel().Id });

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
           => MyController<JobsController>
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
        public void JobSchouldReturnErrorWhenJobIdNotExist(int id)
           => MyMvc.Controller<JobsController>()
               .WithoutData()
               .Calling(c => c.Job(id))
               .ShouldReturn()
               .RedirectToAction("Error", "Home");

        [Theory]
        [InlineData(1)]
        public void JobSchouldReturnViewWithTheRequetedJobId(int id)
          => MyMvc.Controller<JobsController>()
              .WithData(
                    GetUser(),
                    GetJob())
              .Calling(c => c.Job(id))
              .ShouldReturn()
              .View(v => v.WithModelOfType<SigleJobViewModel>(m => m.Id
                    .ShouldBe(id)));

        [Theory]
        [InlineData(1, 1)]
        public void AllSchouldReturnViewWithTheDefaultEntitiesCountPerPage(int expectedCount, int page)
           => MyMvc.Controller<JobsController>()
               .WithData(
                    GetUser(),
                    GetJob())
               .Calling(c => c.All(page))
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<AllJobsViewModel>(m => m.Jobs.Count()
                        .ShouldBe(expectedCount)));

        [Fact]
        public void SearchShouldRedirectToAllWhenSearchTermIsNull()
        => MyMvc.Controller<JobsController>()
              .WithData(GetJob())
              .Calling(c => c.Search(null, 1))
              .ShouldReturn()
              .RedirectToAction("All");

        [Theory]
        [InlineData("Test", 1, 1)]
        public void SearchShouldReturnViewWithJobsWhenSearchTermIsValid(string searchTerm, int page, int expectedCount)
             => MyMvc.Controller<JobsController>()
                   .WithData(
                        GetJob(),
                        GetUser())
                   .Calling(c => c.Search(searchTerm, page))
                   .ShouldHave()
                   .TempData(t => t.Equals(searchTerm))
                   .AndAlso()
                   .ShouldReturn()
                   .View(v => v
                         .WithModelOfType<AllJobsViewModel>(m => m.Jobs.Count()
                        .ShouldBe(expectedCount)));
    }
}
