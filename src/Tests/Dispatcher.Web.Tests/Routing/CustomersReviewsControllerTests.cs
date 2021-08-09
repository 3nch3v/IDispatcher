namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CustomersReviewsControllerTests
    {
        [Theory]
        [InlineData("fakeid")]
        public void AllRouteShouldBeMapped(string id)
          => MyRouting
          .Configuration()
          .ShouldMap($"/CustomersReviews/All/{id}")
          .To<CustomersReviewsController>(c => c
              .All(id));
    }
}
