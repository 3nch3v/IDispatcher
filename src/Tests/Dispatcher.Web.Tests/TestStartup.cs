namespace Dispatcher.Web.Tests
{
    using System.Reflection;

    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            this.ConfigureServices(services);

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }
    }
}
