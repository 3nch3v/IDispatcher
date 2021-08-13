namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Controllers;
    using Dispatcher.Web.ViewModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Common.GlobalConstants.ErrorMessage;

    public class HomeControllerTests
    {
        [Fact]
        public void IndexShouldReturnViewWhenCollingIndexAction()
            => MyMvc
                .Controller<HomeController>(instance => instance
                    .WithoutUser())
                .Calling(c => c.Index())
                .ShouldReturn()
                .View();

        [Fact]
        public void PrivacyShouldReturnViewWhenCollingIndexAction()
            => MyMvc
                .Controller<HomeController>(instance => instance
                    .WithoutUser())
                .Calling(c => c.Privacy())
                .ShouldReturn()
                .View();

        [Fact]
        public void ErrorShouldReturnViewWithBadRequestWhenCollingIndexActionWithError400()
            => MyMvc
                .Controller<HomeController>(instance => instance
                    .WithoutUser())
                .Calling(c => c.Error(400))
                .ShouldHave()
                .ViewBag(viewBag => viewBag
                    .ContainingEntry("ErrorMessage", BadRequest))
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void ErrorShouldReturnViewWithUnauthorisedWhenCollingIndexActionWithError401()
            => MyMvc
                .Controller<HomeController>(instance => instance
                    .WithUser(user => user
                        .WithUsername("Gosho")))
                .Calling(c => c.Error(401))
                .ShouldHave()
                    .ActionAttributes(attrubute => attrubute
                        .CachingResponse())
                .AndAlso()
                .ShouldHave()
                .ViewBag(viewBag => viewBag
                    .ContainingEntry("ErrorMessage", Unauthorised))
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void ErrorShouldReturnViewWithError404NotFound()
           => MyMvc
            .Controller<HomeController>(instance => instance
                .WithUser(user => user
                    .WithUsername("Gosho")))
            .Calling(c => c.Error(404))
            .ShouldHave()
                .ActionAttributes(attrubute => attrubute
                    .CachingResponse())
            .AndAlso()
            .ShouldHave()
            .ViewBag(viewBag => viewBag
                .ContainingEntry("ErrorMessage", NotFound))
            .AndAlso()
            .ShouldReturn()
            .View(view => view.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void ErrorShouldReturnViewWithError403Forbidden()
         => MyMvc
            .Controller<HomeController>(instance => instance
                .WithUser(user => user
                    .WithUsername("Gosho")))
            .Calling(c => c.Error(403))
            .ShouldHave()
                .ActionAttributes(attrubute => attrubute
                    .CachingResponse())
            .AndAlso()
            .ShouldHave()
            .ViewBag(viewBag => viewBag
                .ContainingEntry("ErrorMessage", Forbidden))
            .AndAlso()
            .ShouldReturn()
            .View(view => view.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void ErrorShouldReturnViewWithError500ServerError()
            => MyMvc
                .Controller<HomeController>(instance => instance
                    .WithUser(user => user
                        .WithUsername("Gosho")))
                .Calling(c => c.Error(500))
                .ShouldHave()
                    .ActionAttributes(attrubute => attrubute
                        .CachingResponse())
                .AndAlso()
                .ShouldHave()
                .ViewBag(viewBag => viewBag
                    .ContainingEntry("ErrorMessage", ServerError))
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void ErrorShouldReturnViewWithError502BadGateway()
             => MyMvc
                .Controller<HomeController>(instance => instance
                    .WithUser(user => user
                        .WithUsername("Gosho")))
                .Calling(c => c.Error(502))
                .ShouldHave()
                    .ActionAttributes(attrubute => attrubute
                        .CachingResponse())
                .AndAlso()
                .ShouldHave()
                .ViewBag(viewBag => viewBag
                    .ContainingEntry("ErrorMessage", BadGateway))
                .AndAlso()
                .ShouldReturn()
                .View(view => view.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void ErrorShouldReturnViewWithError505HttpNotSupported()
            => MyMvc
               .Controller<HomeController>(instance => instance
                   .WithUser(user => user
                       .WithUsername("Gosho")))
               .Calling(c => c.Error(505))
               .ShouldHave()
                   .ActionAttributes(attrubute => attrubute
                       .CachingResponse())
               .AndAlso()
               .ShouldHave()
               .ViewBag(viewBag => viewBag
                   .ContainingEntry("ErrorMessage", HttpNotSupported))
               .AndAlso()
               .ShouldReturn()
               .View(view => view.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void ErrorShouldReturnViewWithErrorNotFoundWhenStatusCodeNotSupported()
           => MyMvc
              .Controller<HomeController>(instance => instance
                  .WithUser(user => user
                      .WithUsername("Gosho")))
              .Calling(c => c.Error(default))
              .ShouldHave()
                  .ActionAttributes(attrubute => attrubute
                      .CachingResponse())
              .AndAlso()
              .ShouldHave()
              .ViewBag(viewBag => viewBag
                  .ContainingEntry("ErrorMessage", NotFound))
              .AndAlso()
              .ShouldReturn()
              .View(view => view.WithModelOfType<ErrorViewModel>());
    }
}
