namespace Dispatcher.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Models.AdvertisementModels;

    public class JobSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Jobs.Any())
            {
                return;
            }

            var jobs = new List<Job>();

            for (int i = 0; i < 12; i++)
            {
                jobs.Add(new Job
                {
                    Title = "IT support Technician(Night Shift) Office Based Sofia",
                    JobBody = "This role calls for exceptional client-facing communication skills, utmost professionalism, " +
                "a logical approach to troubleshooting and a personal drive to learn new systems and skills. If you get" +
                " pleasure out of delivering outstanding response times, exceptional customer service and enjoy variety, " +
                "then please read on as this may be the job for you! " +
                "- Microsoft Windows Server and Desktop OS(2012r2 - 2019 / Windows 10) " +
                "- Microsoft Exchange server 2016 - 2019 " +
                "- Active Directory & IIS " +
                "- Microsoft Office 2003 - 2010 " +
                "- Backup systems(Symantec Backup Exec) " +
                "- Wireless devices and configurations(BlackBerry / iPhone / Android / Windows mobile) " +
                "- Computer hardware and related devices " +
                "- Desktop applications",
                    Location = "Sofia, Bulgaria",
                    CompanyName = "Softuni",
                    Contact = "0902300934909034, ivan.Enchev@haha.bg",
                    LogoUrl = "https://w7.pngwing.com/pngs/269/405/png-transparent-career-development-job-application-for-employment-business-career-miscellaneous-trademark-logo.png",
                    UserId = "b89ddf98-f0e1-419c-b9a9-815eb400713b",
                });
            }

            await dbContext.AddRangeAsync(jobs);
        }
    }
}
