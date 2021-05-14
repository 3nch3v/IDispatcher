namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class AdsService : IAdsService
    {
        private readonly IDeletableEntityRepository<Advertisement> advertisementRepository;

        public AdsService(IDeletableEntityRepository<Advertisement> advertisementRepository)
        {
            this.advertisementRepository = advertisementRepository;
        }

        public T GetAd<T>(int id)
        {
            var ad = this.advertisementRepository
                .AllAsNoTracking()
                .Where(a => a.Id == id)
                .To<T>()
                .FirstOrDefault();

            return ad;
        }

        public IEnumerable<T> GetAllAds<T>()
        {
            var ads = this.advertisementRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return ads;
        }
    }
}
