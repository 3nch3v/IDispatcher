namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.AdModels;

    public class AdsService : IAdsService
    {
        private readonly IDeletableEntityRepository<Advertisement> advertisementRepository;
        private readonly IDeletableEntityRepository<AdvertisementType> adTypesRepository;

        public AdsService(
            IDeletableEntityRepository<Advertisement> advertisementRepository,
            IDeletableEntityRepository<AdvertisementType> adTypesRepository)
        {
            this.advertisementRepository = advertisementRepository;
            this.adTypesRepository = adTypesRepository;
        }

        public async Task CreateAsync(AdInputModel input, string userId)
        {
            var newAd = AutoMapperConfig.MapperInstance.Map<Advertisement>(input);
            newAd.UserId = userId;
            await this.advertisementRepository.AddAsync(newAd);
            await this.advertisementRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ad = this.advertisementRepository.All().FirstOrDefault(a => a.Id == id);
            this.advertisementRepository.Delete(ad);
            await this.advertisementRepository.SaveChangesAsync();
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

        public IEnumerable<T> GetAllAdTypes<T>()
        {
            var adTypes = this.adTypesRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return adTypes;
        }

        public async Task UpdateAsync(AdInputModel input, int id)
        {
            var ad = this.advertisementRepository.All().FirstOrDefault(a => a.Id == id);
            ad.Title = input.Title;
            ad.Description = input.Description;
            ad.AdvertisementTypeId = input.AdvertisementTypeId;
            ad.Title = input.Title;
            ad.Compensation = input.Compensation;
            ad.PictureUrl = input.PictureUrl;

            await this.advertisementRepository.SaveChangesAsync();
        }
    }
}
