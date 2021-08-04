namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    public class AdsControllerTests
    {
        public AdsControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(AdViewModel).Assembly, typeof(Advertisement).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(Advertisement).Assembly, typeof(AdViewModel).Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

        [Fact]
        public void CreateShouldHaveAuthorizeAttribute()
           => MyMvc
           .Controller<AdsController>(instance => instance
               .WithUser())
           .Calling(c => c.Create())
           .ShouldHave()
           .ActionAttributes(a => a
               .ContainingAttributeOfType<AuthorizeAttribute>())
           .AndAlso()
           .ShouldReturn()
           .View(view => view
               .WithModelOfType<AdInputModel>());

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldReturnViewWhenModelStateIsInvalid()
            => MyMvc
            .Controller<AdsController>(instance => instance
                .WithUser())
            .Calling(c => c.Create(new AdInputModel()))
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
                WithModelOfType<AdInputModel>());

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldRedirectToAllWhenModelStateIsValid()
           => MyMvc
           .Controller<AdsController>(instance => instance
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
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnViewWithTheEntityWhenUserHasPermission(int adId)
            => MyController<AdsController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetAd())
                .Calling(c => c.Edit(adId))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .View(v => v
                    .WithModelOfType<EditAdViewModel>(m => m.Id
                        .ShouldBe(adId)));

        [Fact]
        public void EditShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserIdNotOwner()
            => MyMvc.Controller<AdsController>()
                .WithUser(u => u.WithUsername("Ivan"))
                .WithData(
                    GetUserNotOwner(),
                    GetAd())
                .Calling(c => c.Edit(1))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnBackInputViewWhenThemodelStateIsInvalid(int adId)
            => MyController<AdsController>
                .Instance()
                .WithUser(u => u.WithIdentifier("1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb"))
                .WithData(
                    GetUser(),
                    GetAd())
                .Calling(c => c.Edit(new AdInputModel { }, adId))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldHave()
                .ActionAttributes(a => a.
                    ContainingAttributeOfType<HttpPostAttribute>())
                .AndAlso()
                .ShouldReturn()
                .View(v => v
                    .WithModelOfType<EditAdViewModel>(m => m.Id
                        .ShouldBe(adId)));

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldRedirectToTheAdWhenUserHasPermissionAndModelStateIsValid(int adId)
          => MyController<AdsController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetAd())
              .Calling(c => c.Edit(GetValidInputModel(), adId))
              .ShouldHave()
              .ActionAttributes(a => a
                  .ContainingAttributeOfType<AuthorizeAttribute>())
              .AndAlso()
              .ShouldHave()
              .ActionAttributes(a => a.
                    ContainingAttributeOfType<HttpPostAttribute>())
              .AndAlso()
              .ShouldReturn()
              .RedirectToAction("Ad");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldRedirectToAllWhenUserHasPermissions(int adId)
            => MyController<AdsController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetAd())
                .Calling(c => c.Delete(adId))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserHasNoPermissionsToDeleteAd(int adId)
            => MyController<AdsController>
                .Instance()
                .WithUser()
                .WithData(
                    GetUserNotOwner(),
                    GetAd())
                .Calling(c => c.Delete(adId))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .Unauthorized();

        [Theory]
        [InlineData(1)]
        public void AdSchouldReturnAdViewModelWhenTheAdIdIsCorrect(int adId)
            => MyMvc.Controller<AdsController>()
                .WithoutData()
                .Calling(c => c.Ad(adId))
                .ShouldReturn()
                .RedirectToAction("Error", "Home");

        [Theory]
        [InlineData(1)]
        public void Test(int adId)
            => MyController<AdsController>
                .Instance()
                .WithData(dbContext => dbContext
                    .WithSet<Advertisement>(a => a.Add(GetAd())))
                .Calling(c => c.Ad(adId))
                .ShouldReturn()
                .View();

        private static AdInputModel GetValidInputModel()
        {
            return new AdInputModel
            {
                AdvertisementTypeId = 1,
                Title = "My fake Ad",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Compensation = "100 marki",
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

        private static Advertisement GetAd()
        {
            return new Advertisement
            {
                Id = 1,
                AdvertisementTypeId = 1,
                Title = "Looking for Developers",
                Description = "Does Upwork, Toptal, Stack Overflow sound familiar to you? If you’re looking to hire developers for your startup, you probably have already bumped into these websites and had no luck in finding the right person for the job. When you’re in the early stages of your business, making sure that you hire the right person for the role is vital. With 20% of startups failing in the first two years, and almost a quarter of failures being due to teamwork issues, getting this right is fundamental. We are familiar with the challenges, as we have been recruiting developers from all over the globe and placing them in different companies, for more than 10 years",
                Compensation = "6000 EUR",
                UserId = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
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
