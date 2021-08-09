namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels.AdModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class AdsControllerTests
    {
        [Fact]
        public void CreateRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Ads/Create")
            .To<AdsController>(c => c
                .Create());

        [Fact]
        public void CreateRouteWithPostMethodShouldBeMapped()
           => MyRouting
           .Configuration()
           .ShouldMap(request => request
                .WithPath("/Ads/Create")
                .WithMethod(HttpMethod.Post))
           .To<AdsController>(c => c
               .Create(new AdvertisementInputModel()));

        [Theory]
        [InlineData(1)]
        public void EditRouteShouldBeMapped(int id)
           => MyRouting
           .Configuration()
           .ShouldMap($"/Ads/Edit/{id}")
           .To<AdsController>(c => c
               .Edit(id));

        [Theory]
        [InlineData(1)]
        public void EditRouteWithPostMethodShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
               .WithPath($"/Ads/Edit/{id}")
               .WithMethod(HttpMethod.Post))
          .To<AdsController>(c => c
              .Edit(new AdvertisementInputModel(), id));

        [Theory]
        [InlineData(1)]
        public void DeleteRouteShouldBeMapped(int id)
          => MyRouting
          .Configuration()
          .ShouldMap($"/Ads/Delete/{id}")
          .To<AdsController>(c => c
              .Delete(id));

        [Theory]
        [InlineData(1)]
        public void AdRouteShouldBeMapped(int id)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Ads/Ad/{id}")
         .To<AdsController>(c => c
             .Ad(id));

        [Theory]
        [InlineData(1)]
        public void AllRouteShouldBeMapped(int page)
        => MyRouting
        .Configuration()
        .ShouldMap($"/Ads/All?page={page}")
        .To<AdsController>(c => c
            .All(page));

        [Theory]
        [InlineData("it", 1)]
        public void SearchRouteShouldBeMapped(string keywords, int page)
         => MyRouting
             .Configuration()
             .ShouldMap($"/Ads/Search?page={page}&keyWords={keywords}")
             .To<AdsController>(c => c
                 .Search(keywords, page));
    }
}
