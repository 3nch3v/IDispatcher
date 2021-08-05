namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data;
    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Repositories;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Microsoft.Extensions.Caching.Memory;
    using Xunit;

    public class AdsServiceTests
    {
        public AdsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(Ad).Assembly, typeof(Advertisement).Assembly);
        }

        [Fact]
        public async Task CreateAsyncShouldAddNewAdInDb()
        {
            var service = GetService(GetAdsRepository());
            var newAd = GetInputModel();

            await service.CreateAsync<AdInputModel>(newAd, GetUserId());
            var actualCount = service.AdsCount();

            Assert.Equal(5, actualCount);
        }

        [Fact]
        public async Task UpdateAsyncShouldChangeAdInDb()
        {
            var service = GetService(GetAdsRepository());
            var updateModel = GetInputModel();

            await service.UpdateAsync<AdInputModel>(updateModel, 1);
            var actualResult = service.GetById<Ad>(1);

            Assert.Equal("Input", actualResult.Title);
        }

        [Fact]
        public async Task DeleteShouldWorkProperly()
        {
            var service = GetService(GetAdsRepository());

            await service.DeleteAsync(1);
            var actualCount = service.AdsCount();

            Assert.Equal(3, actualCount);
        }

        [Fact]
        public void AdsCountShouldReturnAllAdsCountInDb()
        {
            var service = GetService(GetAdsRepository());

            var actualCount = service.AdsCount();

            Assert.Equal(4, actualCount);
        }

        [Fact]
        public void GetByIdShouldReturnCorrectEntityWithTheGivenAdId()
        {
            var service = GetService(GetAdsRepository());

            var actualAd = service.GetById<Ad>(2);

            Assert.Equal("Test2", actualAd.Title);
        }

        [Fact]
        public void GetAllShouldReturnAllAdsInDb()
        {
            var service = GetService(GetAdsRepository());

            var actualAds = service.GetAll<Ad>(1, 5);

            Assert.Equal(4, actualAds.Count());
        }

        [Fact]
        public void GetCreatorShouldReturnCorrectUserId()
        {
            var service = GetService(GetAdsRepository());

            var actualUserId = service.GetCreatorId(1);

            Assert.Equal("7699db4d-e91c-4dcd-9672-7b88b8484930", actualUserId);
        }

        [Fact]
        public void GetAllAdTypesShouldReturnListWithAllAllowedAdTypesInDb()
        {
            var service = GetService(null, GetAdTypesRepository());

            var actualTypes = service.GetAllAdTypes<AdTypesViewModel>();

            Assert.Equal(3, actualTypes.Count());
        }

        [Fact]
        public void SearchShouldReturnAllAdsWithTheGivenTerms()
        {
            var service = GetService(GetAdsRepository());

            var actualResult = service.SearchResult<Ad>(1, 5, "Test3");
            var actualSearchCount = service.SearchCount();
            var actualAd = actualResult.FirstOrDefault();

            Assert.Equal(1, actualSearchCount);
            Assert.Equal(3, actualAd.Id);
        }

        private static IAdsService GetService(
          IDeletableEntityRepository<Advertisement> advertisementRepository = null,
          IDeletableEntityRepository<AdvertisementType> adTypesRepository = null,
          IMemoryCache memoryCache = null)
        {
            var service = new AdsService(advertisementRepository, adTypesRepository, memoryCache);

            return service;
        }

        private static AdInputModel GetInputModel()
        {
            return new AdInputModel()
            {
                AdvertisementTypeId = 1,
                Title = "Input",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                Compensation = "$400",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
            };
        }

        private static string GetUserId()
        {
            return "7699db4d-e91c-4dcd-9672-7b88b8484930";
        }

        private static async Task<ApplicationDbContext> PrepareDb()
        {
            var data = DataBaseMock.Instance;
            data.Advertisements.Add(new Advertisement()
            {
                Id = 1,
                AdvertisementTypeId = 1,
                Title = "Test1",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                Compensation = "200",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });
            data.Advertisements.Add(new Advertisement()
            {
                Id = 2,
                AdvertisementTypeId = 2,
                Title = "Test2",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                Compensation = "100",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });
            data.Advertisements.Add(new Advertisement()
            {
                Id = 3,
                AdvertisementTypeId = 3,
                Title = "Test3",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                Compensation = "400",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });
            data.Advertisements.Add(new Advertisement()
            {
                Id = 4,
                AdvertisementTypeId = 4,
                Title = "Test4",
                Description = "We Work Remotely is a niche job board for remote jobseekers. It’s the largest, most experienced and dedicated remote only job board ",
                Compensation = "300",
                PictureUrl = "https://www.wpbeginner.com/wp-content/uploads/2021/05/webcomlogo.png",
                UserId = "7699db4d-e91c-4dcd-9672-7b88b8484930",
            });

            data.AdvertisementTypes.Add(new AdvertisementType
            {
                Id = 1,
                Type = "Ad",
            });
            data.AdvertisementTypes.Add(new AdvertisementType
            {
                Id = 2,
                Type = "Free",
            });
            data.AdvertisementTypes.Add(new AdvertisementType
            {
                Id = 3,
                Type = "MoneyMaker",
            });

            await data.SaveChangesAsync();

            return data;
        }

        private static EfDeletableEntityRepository<Advertisement> GetAdsRepository()
        {
            var dbContext = PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<Advertisement>(dbContext);

            return repository;
        }

        private static EfDeletableEntityRepository<AdvertisementType> GetAdTypesRepository()
        {
            var dbContext = PrepareDb().Result;
            var repository = new EfDeletableEntityRepository<AdvertisementType>(dbContext);

            return repository;
        }

        public class Ad : IMapFrom<Advertisement>
        {
            public int Id { get; set; }

            public int AdvertisementTypeId { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string UserId { get; set; }

            public string PictureUrl { get; set; }

            public string Compensation { get; set; }
        }

        public class AdInputModel : IMapTo<Advertisement>
        {
            public int AdvertisementTypeId { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string PictureUrl { get; set; }

            public string Compensation { get; set; }
        }

        public class AdTypesViewModel : IMapFrom<AdvertisementType>
        {
            public int Id { get; set; }

            public string Type { get; set; }
        }
    }
}
