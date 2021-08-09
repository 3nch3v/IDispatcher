namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void IdnexRouteShouldBeMapped()
          => MyRouting
          .Configuration()
          .ShouldMap("/")
          .To<HomeController>(c => c
              .Index());

        [Fact]
        public void PrivacyRouteShouldBeMapped()
         => MyRouting
         .Configuration()
         .ShouldMap("/Home/Privacy")
         .To<HomeController>(c => c
             .Privacy());

        [Theory]
        [InlineData(404)]
        public void ErrorRouteShouldBeMapped(int code)
         => MyRouting
         .Configuration()
         .ShouldMap($"/Home/Error/?code={code}")
         .To<HomeController>(c => c
             .Error(code));
    }
}
