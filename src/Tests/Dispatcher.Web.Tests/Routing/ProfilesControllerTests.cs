namespace Dispatcher.Web.Tests.Routing
{
    using Dispatcher.Web.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ProfilesControllerTests
    {
        [Theory]
        [InlineData("Patkan")]
        public void ProfileRouteShouldBeMapped(string username)
            => MyRouting
            .Configuration()
            .ShouldMap($"/Profiles/Profile?username={username}")
            .To<ProfilesController>(c => c
                .Profile(username));

        [Theory]
        [InlineData("Patkan")]
        public void DataManagerRouteShouldBeMapped(string username)
           => MyRouting
           .Configuration()
           .ShouldMap($"/Profiles/DataManager?username={username}")
           .To<ProfilesController>(c => c
               .DataManager(username));
    }
}
