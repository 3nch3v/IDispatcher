using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Dispatcher.Web.Areas.Identity.IdentityHostingStartup))]

namespace Dispatcher.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}
