namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Areas.Administration.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class DashboardControllerTest
    {
        [Fact]
        public void IndexRouteShouldBeMapped()
            => MyRouting
            .Configuration()
            .ShouldMap("/Administration/Dashboard")
            .To<DashboardController>(c => c
                .Index());
    }
}
