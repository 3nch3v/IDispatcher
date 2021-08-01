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
    using Microsoft.Extensions.Caching.Memory;

    public class AdsService : IAdsService
    {
        private readonly IDeletableEntityRepository<Advertisement> advertisementRepository;
        private readonly IDeletableEntityRepository<AdvertisementType> adTypesRepository;
        private readonly IMemoryCache memoryCache;
        private int searchResultCount;

        public AdsService(
            IDeletableEntityRepository<Advertisement> advertisementRepository,
            IDeletableEntityRepository<AdvertisementType> adTypesRepository,
            IMemoryCache memoryCache)
        {
            this.advertisementRepository = advertisementRepository;
            this.adTypesRepository = adTypesRepository;
            this.memoryCache = memoryCache;
        }

        public async Task CreateAsync<T>(T input, string userId)
        {
            var ad = AutoMapperConfig.MapperInstance.Map<Advertisement>(input);
            ad.UserId = userId;

            await this.advertisementRepository.AddAsync(ad);
            await this.advertisementRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T input, int id)
        {
            var update = AutoMapperConfig.MapperInstance.Map<Advertisement>(input);

            var ad = this.advertisementRepository.All().FirstOrDefault(a => a.Id == id);

            if (ad.Title != update.Title)
            {
                ad.Title = update.Title;
            }

            if (ad.Description != update.Description)
            {
                ad.Description = update.Description;
            }

            if (ad.AdvertisementTypeId != update.AdvertisementTypeId)
            {
                ad.AdvertisementTypeId = update.AdvertisementTypeId;
            }

            if (ad.Compensation != update.Compensation)
            {
                ad.Compensation = update.Compensation;
            }

            if (ad.PictureUrl != update.PictureUrl)
            {
                ad.PictureUrl = update.PictureUrl;
            }

            await this.advertisementRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ad = this.advertisementRepository.All().FirstOrDefault(a => a.Id == id);

            this.advertisementRepository.Delete(ad);
            await this.advertisementRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var ad = this.advertisementRepository
                .All()
                .Where(a => a.Id == id)
                .To<T>()
                .FirstOrDefault();

            return ad;
        }

        public IEnumerable<T> GetAll<T>(int page, int pageEntitiesCount)
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
            var ads = this.memoryCache
                .GetOrCreate("RandomAds", entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                    return this.advertisementRepository
                            .AllAsNoTracking()
                            .OrderBy(a => Guid.NewGuid())
                            .To<T>()
                            .Take(adsCount)
                            .ToList();
                });

            return ads;
        }

        public IEnumerable<T> SearchResult<T>(int page, int pageEntitiesCount, string keyWords)
        {
            string[] searchingKeyWords = keyWords.
                ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var query = this.advertisementRepository.AllAsNoTracking().AsQueryable();

            foreach (var word in searchingKeyWords)
            {
                query = query.Where(a => a.Title.ToLower().Contains(word)
                                 || a.Description.ToLower().Contains(word)
                                 || searchingKeyWords.Contains(a.AdvertisementType.Type)
                                 || a.Compensation.Contains(word));
            }

            this.searchResultCount = query.Count();

            var result = query
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return result;
        }

        public string GetCreatorId(int id)
        {
            var ad = this.advertisementRepository
                .AllAsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefault();

            return ad?.UserId;
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
