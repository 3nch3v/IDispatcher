namespace Dispatcher.Web.Tests
{
    using System.Reflection;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels;
    using Dispatcher.Web.ViewModels.AdModels;
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
            AutoMapperConfig.RegisterMappings(
                Assembly.Load("Dispatcher.Web.ViewModels"),
                Assembly.Load("Dispatcher.Data.Models"),
                Assembly.Load("Dispatcher.Web"));
            AutoMapperConfig.RegisterMappings(typeof(AdvertisementViewModel).Assembly, typeof(Advertisement).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(Advertisement).Assembly, typeof(AdvertisementViewModel).Assembly);
        }
    }
}
