namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.AdvertisementModels;

    public class AdvertisementSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Advertisements.Any())
            {
                return;
            }

            var ads = new List<Advertisement>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var newAd = new Advertisement
                    {
                        AdvertisementTypeId = j + 1,
                        Title = $"{1 + i + j} Looking for {j}",
                        Description = "Led by our professors and mentors, our students are exposed to real-life experience in interdisciplinary teams. Our partners are invited to contribute to this “learning by doing” philosophy and can provide case studies as well as delegate experts to come share in person.",
                        Compensation = "300 EUR",
                        UserId = "6b4f487f-5cde-4509-825b-103b69220131",
                        IsActive = true,
                        PictureUrl = "https://code.berlin/content/uploads/b1b42b4e-1800x1202.jpg",
                    };

                    ads.Add(newAd);
                }
            }

            await dbContext.Advertisements.AddRangeAsync(ads);
        }
    }
}
