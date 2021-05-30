namespace Dispatcher.Services.Data
{
    using System;
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
        private int searchResultCount;

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

        public IEnumerable<T> GetAllAds<T>(int page, int pageEntitiesCount)
        {
            var ads = this.advertisementRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
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

        public IEnumerable<T> RandomAds<T>(int adsCount)
        {
            var randomAds = this.advertisementRepository.AllAsNoTracking()
                .OrderBy(a => Guid.NewGuid())
                .To<T>()
                .Take(adsCount)
                .ToList();

            return randomAds;
        }

        public IEnumerable<T> SearchResults<T>(int page, int pageEntitiesCount, string keyWords)
        {
            string[] searchingKeyWords = keyWords.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var query = this.advertisementRepository.All().AsQueryable();

            foreach (var word in searchingKeyWords)
            {
                query = query.Where(a => a.Title.ToLower().Contains(word)
                || a.Description.ToLower().Contains(word)
                || searchingKeyWords.Contains(a.AdvertisementType.Type)
                || a.Compensation.Contains(word));
            }

            this.searchResultCount = query
                .To<T>()
                .ToList().Count();

            var result = query
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return result;
        }

        public int SearchCount()
        {
            return this.searchResultCount;
        }

        public int AdsCount()
        {
            return this.advertisementRepository.AllAsNoTracking().Count();
        }
    }
}
