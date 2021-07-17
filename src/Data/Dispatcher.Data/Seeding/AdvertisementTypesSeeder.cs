namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Microsoft.Extensions.Configuration;

    public class AdvertisementTypesSeeder : ISeeder
    {
        public async Task SeedAsync(
            ApplicationDbContext dbContext,
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            if (dbContext.AdvertisementTypes.Any())
            {
                return;
            }

            var adTypes = new List<AdvertisementType>
            {
                new AdvertisementType { Type = "Partners" },
                new AdvertisementType { Type = "Customers" },
                new AdvertisementType { Type = "Employers" },
                new AdvertisementType { Type = "Volunteers" },
            };

            await dbContext.AdvertisementTypes.AddRangeAsync(adTypes);
        }
    }
}
