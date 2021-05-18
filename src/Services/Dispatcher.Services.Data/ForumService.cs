namespace Dispatcher.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class ForumService : IForumService
    {
        private readonly IDeletableEntityRepository<Discussion> forumRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public ForumService(
            IDeletableEntityRepository<Discussion> forumRepository,
            IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.forumRepository = forumRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task CreateAsync<T>(T input, string id)
        {
            var discussion = AutoMapperConfig.MapperInstance.Map<Discussion>(input);
            discussion.UserId = id;

            await this.forumRepository.AddAsync(discussion);
            await this.forumRepository.SaveChangesAsync();
        }

        public int ForumDiscussionsCount()
        {
            return this.forumRepository.All().Count();
        }

        public IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount)
        {
            var forumPosts = this.forumRepository.AllAsNoTracking()
                .OrderByDescending(p => p.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return forumPosts;
        }

        public IEnumerable<T> GetCategories<T>()
        {
            var categories = this.categoriesRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return categories;
        }

        public T GetDiscussion<T>(int id)
        {
            var discussion = this.forumRepository.AllAsNoTracking()
                .Where(d => d.Id == id)
                .To<T>()
                .FirstOrDefault();

            return discussion;
        }
    }
}
