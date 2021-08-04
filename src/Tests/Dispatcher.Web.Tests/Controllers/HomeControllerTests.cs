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
            .View(view => view.WithNoModel());

        [Fact]
        public void PrivacyShouldReturnViewWhenCollingIndexAction()
            => MyMvc
            .Controller<HomeController>(instance => instance
                .WithoutUser())
            .Calling(c => c.Privacy())
            .ShouldReturn()
            .View(view => view.WithNoModel());

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
    }
}
