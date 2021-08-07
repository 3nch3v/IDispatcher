namespace Dispatcher.Web.Tests.Controllers
{
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Web.Areas.Administration.Controllers;
    using Dispatcher.Web.ViewModels.Administration;
    using Dispatcher.Web.ViewModels.Administration.Dashboard;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class AdministrationControllerTests
    {
        public static string UserId => "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb";

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

        private static ApplicationUser GetUser()
        {
            return new ApplicationUser
            {
                Id = "1b99c696-64f5-443a-ae1e-6b4a1bc8f2cb",
                UserName = "Ivan_Dev",
                Email = "ivan@fake.bg",
                PasswordHash = "sdasd324olkk34dff",
            };
        }

        private static CustomerReview GetReview()
        {
            return new CustomerReview
            {
                Id = 1,
                AppraiserId = "testId",
                Comment = "Passssttt",
                StarsCount = 3,
                UserId = UserId,
            };
        }
    }
}
