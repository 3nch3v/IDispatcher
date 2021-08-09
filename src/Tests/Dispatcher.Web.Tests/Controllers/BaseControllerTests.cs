namespace Dispatcher.Web.Tests.Controllers
{
    using System.Reflection;

    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels;

    public class BaseControllerTests
    {
        public BaseControllerTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }
    }
}
