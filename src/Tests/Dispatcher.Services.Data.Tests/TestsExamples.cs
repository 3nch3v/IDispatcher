﻿namespace Dispatcher.Services.Data.Tests
{
    using Xunit;

    public class TestsExamples
    {
        [Fact]
        public void GetCountShouldReturnCorrectNumber()
        {
            ////var repository = new Mock<IDeletableEntityRepository<Setting>>();
            ////repository.Setup(r => r.All()).Returns(new List<Setting>
            ////                                            {
            ////                                                new Setting(),
            ////                                                new Setting(),
            ////                                                new Setting(),
            ////                                            }.AsQueryable());
            ////var service = new SettingsService(repository.Object);
            ////Assert.Equal(3, service.GetCount());
            ////repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public void GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            ///// async Task
            ////var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            ////    .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            ////using var dbContext = new ApplicationDbContext(options);
            ////dbContext.Settings.Add(new Setting());
            ////dbContext.Settings.Add(new Setting());
            ////dbContext.Settings.Add(new Setting());
            ////await dbContext.SaveChangesAsync();

            ////using var repository = new EfDeletableEntityRepository<Setting>(dbContext);
            ////var service = new SettingsService(repository);
            ////Assert.Equal(3, service.GetCount());
        }

        [Fact]
        public void AdsCountShouldeReturnCorrectCountWithMock()
        {
            ////    var repository = new Mock<IDeletableEntityRepository<Advertisement>>();
            ////    repository.Setup(r => r.AllAsNoTracking()).Returns(new List<Advertisement>
            ////                                                {
            ////                                                    new Advertisement(),
            ////                                                    new Advertisement(),
            ////                                                    new Advertisement(),
            ////                                                }.AsQueryable());

            ////    var service = new AdsService(repository.Object, null, null);
            ////    Assert.Equal(3, service.AdsCount());
        }
    }
}
