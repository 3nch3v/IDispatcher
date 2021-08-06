﻿namespace Dispatcher.Web.Tests.Controllers
{
    using System.Linq;
    using System.Reflection;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
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
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

        [Fact]
        public void CreateShouldHaveAuthorizeAttributeAndReturnViewWithTheAdTypes()
           => MyController<AdsController>
            .Instance()
            .WithUser(u => u.WithIdentifier(UserId))
            .WithData(GetAdType())
            .Calling(c => c.Create())
            .ShouldHave()
            .ActionAttributes(a => a
                .ContainingAttributeOfType<AuthorizeAttribute>())
            .AndAlso()
            .ShouldReturn()
            .View(view => view
                .WithModelOfType<AdvertisementInputModel>(v => v
                 .AdvertisementTypes.Count() == 1
                 && v.AdvertisementTypes.First().Type == "TestType"));

        [Fact]
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldReturnViewWhenModelStateIsInvalid()
            => MyMvc
            .Controller<AdsController>(instance => instance
                .WithUser())
            .Calling(c => c.Create(new AdvertisementInputModel()))
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
                WithModelOfType<AdvertisementInputModel>());

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
                    GetAd(),
                    GetAdType())
                .Calling(c => c.Edit(adId))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .View(v => v
                    .WithModelOfType<EditAdvertisementViewModel>(m => m.Id == adId
                    && m.AdvertisementTypes.Count() == 1));

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
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetAd(),
                    GetAdType())
                .Calling(c => c.Edit(new AdvertisementInputModel { }, adId))
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
                    .WithModelOfType<EditAdvertisementViewModel>(m => m.Id
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
              .ShouldHave()
              .ValidModelState()
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
        public void AdSchouldReturnErrorWhenTheAdIdIsNotCorrectOrMissing(int adId)
            => MyMvc.Controller<AdsController>()
                .WithoutData()
                .Calling(c => c.Ad(adId))
                .ShouldReturn()
                .RedirectToAction("Error", "Home");

        [Theory]
        [InlineData(1)]
        public void AdSchouldReturnTheAdWithTheCalledIdWhenTheAdIdIsCorrect(int adId)
            => MyMvc.Controller<AdsController>()
                .WithData(GetAd())
                .Calling(c => c.Ad(adId))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AdvertisementViewModel>(v => v
                        .Id.ShouldBe(1)));

        [Fact]
        public void AllSchouldReturnViewWithTheDefaultEntitiesCountPerPage()
            => MyMvc.Controller<AdsController>()
                .WithData(GetAd())
                .Calling(c => c.All(1))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AllAdvertisementsViewModel>(v => v.Advertisements.Count() == 1));

        [Fact]
        public void SearchShouldRedirectToAllAdsWhenSearchTermIsNull()
          => MyMvc.Controller<AdsController>()
                .WithData(GetAd())
                .Calling(c => c.Search(null, 1))
                .ShouldReturn()
                .RedirectToAction("All");

        [Fact]
        public void SearchShouldReturnViewWithAdsWhenSearchTermIsValid()
         => MyMvc.Controller<AdsController>()
               .WithData(GetAd())
               .Calling(c => c.Search("Id", 1))
               .ShouldReturn()
               .View(v => v
                    .WithModelOfType<AllAdvertisementsViewModel>());

        private static AdvertisementInputModel GetValidInputModel()
        {
            return new AdvertisementInputModel
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

        private static AdvertisementType GetAdType()
        {
            return new AdvertisementType { Id = 1, Type = "TestType" };
        }
    }
}
