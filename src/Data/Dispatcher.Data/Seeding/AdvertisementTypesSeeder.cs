namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.AdvertisementModels;

    public class AdvertisementTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.AdvertisementTypes.Any())
            {
                return;
            }

            var adTypes = new List<AdvertisementType>();
            adTypes.Add(new AdvertisementType { Type = "Partners" });
            adTypes.Add(new AdvertisementType { Type = "Customers" });
            adTypes.Add(new AdvertisementType { Type = "Employers" });
            adTypes.Add(new AdvertisementType { Type = "Volunteers" });

            await dbContext.AdvertisementTypes.AddRangeAsync(adTypes);
        }
    }
}
