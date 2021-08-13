namespace Dispatcher.Web.Tests.ViewComponents
{
    using Dispatcher.Web.ViewComponents;
    using Dispatcher.Web.ViewModels.ViewComponents;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class RandomJobsViewComponentTests
    {
        [Fact]
        public void ForumSideBarViewComponentShouldReturnViewWithOut()
            => MyViewComponent<RandomJobsViewComponent>
                .Instance()
                .WithData(GetJob())
                .InvokedWith(v => v.Invoke())
                .ShouldReturn()
                .View(v => v.WithModelOfType<RandomJobsModel>());
    }
}
