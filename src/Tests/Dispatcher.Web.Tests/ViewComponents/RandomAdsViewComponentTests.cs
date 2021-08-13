namespace Dispatcher.Web.Tests.ViewComponents
{
    using Dispatcher.Web.ViewComponents;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class RandomAdsViewComponentTests
    {
        [Theory]
        [InlineData(1)]
        public void ForumSideBarViewComponentShouldReturnView(int adCount)
          => MyViewComponent<RandomAdsViewComponent>
            .Instance()
            .WithData(GetAd())
            .InvokedWith(v => v.Invoke(adCount))
            .ShouldReturn()
            .View(v => v.WithModelOfType<RandomAdsModel>());
    }
}
