namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Web.Areas.Administration.Controllers;
    using Dispatcher.Web.ViewModels.Administration;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static Dispatcher.Web.Tests.Data;

    public class AdministrationControllerTests : BaseControllerTests
    {
        [Fact]
        public void GetDataShouldRedirectToDashboardWhenSearchInputIsNotValid()
         => MyController<AdministrationController>
             .Instance()
             .WithUser()
             .WithData(GetUser())
             .Calling(c => c.GetData(new SearchInputModel()))
             .ShouldReturn()
             .RedirectToAction("Index", "Dashboard");

        [Theory]
        [InlineData("Review", "Id", "1")]
        [InlineData("User", "Username", "Ivan_Dev")]
        public void GetDataShouldRetunrCalledDataWhenSearchInputIsValid(string dataType, string searchMethod, string searchTerm)
         => MyController<AdministrationController>
             .Instance()
             .WithUser()
             .WithData(
                GetUser(),
                GetReview())
             .Calling(c => c.GetData(new SearchInputModel() { SearchData = dataType, SearchMethod = searchMethod, SearchTerm = searchTerm }))
             .ShouldReturn()
             .View(v => v.WithModelOfType<SearchDataViewmodel>());

        [Fact]
        public void DeleteUserShouldRedirectToDashboardWhenUserHasBeenDeleted()
        => MyController<AdministrationController>
            .Instance()
            .WithUser()
            .WithData(GetUser())
            .Calling(c => c.DeleteUser(UserId))
            .ShouldReturn()
            .RedirectToAction("Index", "Dashboard");

        [Theory]
        [InlineData(1)]
        public void DeleteShouldHaveAuthorizeAttributeAndShouldRedirectToAllWhenUserHasPermissions(int id)
         => MyController<AdministrationController>
             .Instance()
             .WithUser()
             .WithData(GetReview())
             .Calling(c => c.DeleteReview(id))
             .ShouldReturn()
             .RedirectToAction("Index", "Dashboard");
    }
}
