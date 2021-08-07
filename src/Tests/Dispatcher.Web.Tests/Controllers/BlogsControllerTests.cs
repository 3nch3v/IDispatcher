namespace Dispatcher.Web.Tests.Controllers
{
    using System.Reflection;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.BlogModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class BlogsControllerTests
    {
        public BlogsControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

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

        private static BlogInputModel GetValidInputModel()
        {
            return new BlogInputModel { Title = "Test Blog", Body = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " };
        }

        private static EditBlogPostInputmodel GetEditBlogInputmodel()
        {
            return new EditBlogPostInputmodel { Id = 1, Title = "Test Blog", Body = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " };
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

        private static Blog GetBlog()
        {
            return new Blog
            {
                Id = 1,
                Title = "Looking for Developers",
                Body = "Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years",
                UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
            };
        }
    }
}
