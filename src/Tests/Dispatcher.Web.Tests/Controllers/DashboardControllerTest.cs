namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Areas.Administration.Controllers;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class DashboardControllerTest
    {
        [Fact]
        public void IndexReturnViewWitStatisctics()
         => MyController<DashboardController>
          .Instance()
          .WithUser()
          .Calling(c => c.Index())
          .ShouldReturn()
          .View(v => v
                .WithModelOfType<IndexViewModel>());
    }
}
