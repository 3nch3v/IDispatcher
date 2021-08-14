namespace Dispatcher.Services.Data.Tests.DipatcherServicesData
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Web.ViewModels.AdModels;
    using Xunit;

    public class AdsServiceTests : BaseServiceTests
    {
        [Fact]
        public async Task CreateAsyncShouldAddNewAdSuccessfully()
        {
            var service = GetAdService(AdsRepository);
            var input = GetAdInputModel();

            await service.CreateAsync<AdvertisementInputModel>(input, UserId);
            var actualCount = service.AdsCount();

            Assert.Equal(5, actualCount);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdateAsyncShouldModifyAdvertisementWhenDataInputIsDifferent(int adId)
        {
            var service = GetAdService(AdsRepository);
            var input = GetAdInputModel();

            await service.UpdateAsync<AdvertisementInputModel>(input, adId);
            var actualResult = service.GetById<AdvertisementViewModel>(adId);

            Assert.Equal("Input", actualResult.Title);
            Assert.Equal("$400", actualResult.Compensation);
            Assert.Equal("https://www.wpbeginner.com/fake.png", actualResult.PictureUrl);
            Assert.Equal("New We Work Remotely is a niche job board for remote jobseekers.", actualResult.Description);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteShouldWorkProperly(int adId)
        {
            var service = GetAdService(AdsRepository);

            await service.DeleteAsync(adId);
            var actualCount = service.AdsCount();

            int expectedResult = 3;
            Assert.Equal(expectedResult, actualCount);
        }

        [Fact]
        public void AdsCountShouldReturnTheCountOfAds()
        {
            var service = GetAdService(AdsRepository);

            var actualCount = service.AdsCount();

            int expectedResult = 4;
            Assert.Equal(expectedResult, actualCount);
        }

        [Theory]
        [InlineData(2)]
        public void GetByIdShouldReturnAdWithTheGivenId(int adId)
        {
            var service = GetAdService(AdsRepository);

            var actualAd = service.GetById<AdvertisementViewModel>(adId);

            Assert.Equal(adId, actualAd.Id);
            Assert.Equal("Test2", actualAd.Title);
            Assert.Equal("100", actualAd.Compensation);
            Assert.Equal("https://www.wpbeginner.com/fake.png", actualAd.PictureUrl);
            Assert.Equal("2 We Work Remotely is a niche job board for remote jobseekers.", actualAd.Description);
        }

        [Theory]
        [InlineData(1, 5)]
        public void GetAllShouldReturnAllAdsInDb(int page, int entitiesCount)
        {
            var service = GetAdService(AdsRepository);

            var actualAds = service.GetAll<AdvertisementViewModel>(page, entitiesCount);

            int expectedResult = 4;
            Assert.Equal(expectedResult, actualAds.Count());
        }

        [Theory]
        [InlineData(1)]
        public void GetCreatorShouldReturnCorrectUserId(int adId)
        {
            var service = GetAdService(AdsRepository);

            var actualUserId = service.GetCreatorId(adId);

            Assert.Equal(UserId, actualUserId);
        }

        [Fact]
        public void GetAllAdTypesShouldReturnListWithAllAllowedAdTypes()
        {
            var service = GetAdService(null, AdTypesRepository);

            var actualTypes = service.GetAllAdTypes<AdvertisementTypeViewModel>();

            int expectedResult = 3;
            Assert.Equal(expectedResult, actualTypes.Count());
        }

        [Theory]
        [InlineData(1, 5, "Test3")]
        public void SearchShouldReturnAllAdsWithTheGivenTerms(int page, int entitiesCount, string searchTerm)
        {
            var service = GetAdService(AdsRepository);

            var actualResult = service.SearchResult<AdvertisementViewModel>(page, entitiesCount, searchTerm);
            var actualSearchCount = service.SearchCount();
            var actualAd = actualResult.FirstOrDefault();

            int expectedCount = 1;
            int expectedId = 3;
            Assert.Equal(expectedCount, actualSearchCount);
            Assert.Equal(expectedId, actualAd.Id);
        }
    }
}
