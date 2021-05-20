namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.ForumModels;
    using Microsoft.EntityFrameworkCore;

    public class ForumService : IForumService
    {
        private readonly IDeletableEntityRepository<Discussion> forumRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private int forumDiscussionsPerCategoryCount;

        public ForumService(
            IDeletableEntityRepository<Discussion> forumRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Post> postsRepository)
        {
            this.forumRepository = forumRepository;
            this.categoriesRepository = categoriesRepository;
            this.postsRepository = postsRepository;
        }

        public async Task AddCommentAsync<T>(T input)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<Post>(input);

            await this.postsRepository.AddAsync(comment);
            await this.postsRepository.SaveChangesAsync();
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
                .Include(x => x.Votes)
                .OrderByDescending(p => p.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            return forumPosts;
        }

        public IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount, string category)
        {
            var forumPosts = this.forumRepository.AllAsNoTracking()
                .Where(d => d.Category.Name == category)
                .OrderByDescending(p => p.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            this.forumDiscussionsPerCategoryCount = forumPosts.Count();

            return forumPosts;
        }

        public IEnumerable<T> GetUnsolvedDiscussions<T>(int page, int pageEntitiesCount)
        {
            var forumPosts = this.forumRepository.AllAsNoTracking()
                .Where(d => d.IsSolved == false)
                .OrderByDescending(p => p.CreatedOn)
                .Skip((page - 1) * pageEntitiesCount)
                .Take(pageEntitiesCount)
                .To<T>()
                .ToList();

            this.forumDiscussionsPerCategoryCount = forumPosts.Count();

            return forumPosts;
        }

        public int ForumDiscussionsPerCategoryCount()
        {
            return this.forumDiscussionsPerCategoryCount;
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
                .Include(x => x.Votes)
                .Where(d => d.Id == id)
                .To<T>()
                .FirstOrDefault();

            return discussion;
        }

        public int GetUnsolvedCount()
        {
            int unsolvedCount = this.forumRepository
                .AllAsNoTracking()
                .Where(d => d.IsSolved == false)
                .Count();

            return unsolvedCount;
        }

        public async Task DeleteAsync(int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            this.forumRepository.Delete(discussion);
            await this.forumRepository.SaveChangesAsync();
        }

        public async Task SetToSolved(int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            discussion.IsSolved = true;
            await this.forumRepository.SaveChangesAsync();
        }

        public async Task Edit(DiscussionInputModel input, int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            discussion.Title = input.Title;
            discussion.Description = input.Description;
            discussion.CategoryId = input.CategoryId;

            await this.forumRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var commment = this.postsRepository.All().FirstOrDefault(c => c.Id == id);
            this.postsRepository.Delete(commment);
            await this.postsRepository.SaveChangesAsync();
        }
    }
}
