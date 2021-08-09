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
              .Calling(c => c.Edit(GetAdValidInputModel(), adId))
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

        [Fact]
        public void AllSchouldReturnViewWithTheDefaultEntitiesCountPerPage()
            => MyMvc.Controller<AdsController>()
                .WithData(GetAd())
                .Calling(c => c.All(1))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AllAdvertisementsViewModel>());

        [Fact]
        public void SearchShouldRedirectToAllAdsWhenSearchTermIsNull()
          => MyMvc.Controller<AdsController>()
                .WithData(GetAd())
                .Calling(c => c.Search(null, 1))
                .ShouldReturn()
                .RedirectToAction("All");

        [Theory]
        [InlineData("Id", 1)]
        public void SearchShouldReturnViewWithAdsWhenSearchTermIsValid(string searchTerm, int id)
         => MyMvc.Controller<AdsController>()
               .WithData(GetAd())
               .Calling(c => c.Search(searchTerm, id))
               .ShouldHave()
               .TempData(t => t.Equals(searchTerm))
               .AndAlso()
               .ShouldReturn()
               .View(v => v
                    .WithModelOfType<AllAdvertisementsViewModel>());
    }
}
