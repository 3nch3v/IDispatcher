namespace Dispatcher.Web.Tests.Controllers
{
    using System.Linq;

    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.AdModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Shouldly;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class AdsControllerTests : BaseControllerTests
    {
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
        public void CreateShouldHaveAuthorizeAndHttpPostAttributesShouldReturnViewWhenModelStateIsNotValid()
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
           .Calling(c => c.Create(GetAdValidInputModel()))
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
            => MyController<AdsController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetAd(),
                    GetAdType())
                .Calling(c => c.Edit(id))
                .ShouldHave()
                .ActionAttributes(a => a
                    .ContainingAttributeOfType<AuthorizeAttribute>())
                .AndAlso()
                .ShouldReturn()
                .View(v => v
                    .WithModelOfType<EditAdvertisementViewModel>(m => m.Id == id
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
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldReturnBackInputViewWhenThemodelStateIsInvalid(int id)
            => MyController<AdsController>
                .Instance()
                .WithUser(u => u.WithIdentifier(UserId))
                .WithData(
                    GetUser(),
                    GetAd(),
                    GetAdType())
                .Calling(c => c.Edit(new AdvertisementInputModel { }, id))
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
                        .ShouldBe(id)));

        [Theory]
        [InlineData(1)]
        public void EditShouldHaveAuthorizeAndHttpPostAttributesAndShouldRedirectToTheAdWhenUserHasPermissionAndModelStateIsValid(int id)
          => MyController<AdsController>
              .Instance()
              .WithUser(u => u.WithIdentifier(UserId))
              .WithData(
                  GetUser(),
                  GetAd())
              .Calling(c => c.Edit(GetAdValidInputModel(), id))
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
              .RedirectToAction("Ad", new { id });

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
        public void DeleteShouldHaveAuthorizeAttributeAndShouldReturnUnauthorizedWhenUserHasNoPermissionsToDeleteAd(int id)
            => MyController<AdsController>
                .Instance()
                .WithUser()
                .WithData(
                    GetUserNotOwner(),
                    GetAd())
                .Calling(c => c.Delete(id))
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
        public void AdShouldReturnViewWithTheCalledAdById(int id)
            => MyMvc.Controller<AdsController>()
                .WithData(
                    GetUser(),
                    GetAd(),
                    GetAdType())
                .Calling(c => c.Ad(id))
                .ShouldReturn()
                .View(v => v
                    .WithModelOfType<AdvertisementViewModel>(m => m.Id
                        .ShouldBe(id)));

        [Theory]
        [InlineData(1)]
        public void AllSchouldReturnViewWithAdsPerPage(int page)
            => MyMvc.Controller<AdsController>()
                .WithData(
                    GetUser(),
                    GetAd(),
                    GetAdType())
                .Calling(c => c.All(page))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AllAdvertisementsViewModel>(m => m.Advertisements.Count()
                        .ShouldBe(1)));

        [Fact]
        public void SearchShouldRedirectToAllAdsWhenSearchTermIsNull()
          => MyMvc.Controller<AdsController>()
                .WithData(GetAd())
                .Calling(c => c.Search(null, 1))
                .ShouldReturn()
                .RedirectToAction("All");

        [Theory]
        [InlineData("It", 1)]
        public void SearchShouldReturnViewWithAdsWhenSearchTermIsValid(string searchTerm, int id)
         => MyMvc.Controller<AdsController>()
               .WithData(
                    GetUser(),
                    GetAd(),
                    GetAdType())
               .Calling(c => c.Search(searchTerm, id))
               .ShouldHave()
               .TempData(t => t.Equals(searchTerm))
               .AndAlso()
               .ShouldReturn()
               .View(v => v
                    .WithModelOfType<AllAdvertisementsViewModel>(m => m.Advertisements.Count()
                        .ShouldBe(1)));
    }
}
