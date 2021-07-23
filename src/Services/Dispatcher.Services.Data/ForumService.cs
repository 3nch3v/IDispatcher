namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    using static Dispatcher.Common.GlobalConstants.Forum;

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

        public async Task UpdateAsync<T>(T input, int id)
        {
            var updatedDiscussion = AutoMapperConfig.MapperInstance.Map<Discussion>(input);
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            discussion.Title = updatedDiscussion.Title;
            discussion.Description = updatedDiscussion.Description;
            discussion.CategoryId = updatedDiscussion.CategoryId;

            await this.forumRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            this.forumRepository.Delete(discussion);
            await this.forumRepository.SaveChangesAsync();
        }

        public async Task SetDiscussionToSolvedAsync(int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            discussion.IsSolved = true;
            await this.forumRepository.SaveChangesAsync();
        }

        public int GetDiscussionsCount(string categoty)
        {
            if (categoty == "All")
            {
                return this.forumRepository.All().Count();
            }
            else if (categoty == Unsolved)
            {
                return this.forumRepository.AllAsNoTracking()
               .Where(x => x.IsSolved == false)
               .Count();
            }
            else
            {
                return this.forumRepository.AllAsNoTracking()
               .Where(x => x.Category.Name == categoty)
               .Count();
            }
        }

        public T GetById<T>(int id)
        {
            var discussion = this.forumRepository.AllAsNoTracking()
                .Include(x => x.Votes)
                .Where(d => d.Id == id)
                .To<T>()
                .FirstOrDefault();

            return discussion;
        }

        public IEnumerable<T> GetCategories<T>()
        {
            var categories = this.categoriesRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return categories;
        }

        public IEnumerable<T> GetAllForumDiscussions<T>(int page, int pageEntitiesCount, string category)
        {
            IEnumerable<T> discussions = null;

            if (category == "All")
            {
                discussions = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<T>()
               .ToList();
            }
            else if (category == Unsolved)
            {
                discussions = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .Where(x => x.IsSolved == false)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<T>()
               .ToList();
            }
            else if (!string.IsNullOrEmpty(category))
            {
                discussions = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .Where(x => x.Category.Name == category)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<T>()
               .ToList();
            }

            return discussions;
        }

        public string GetCreatorId(int dataId)
        {
            var discussion = this.forumRepository.AllAsNoTracking()
                .Include(x => x.Votes)
                .Where(d => d.Id == dataId)
                .FirstOrDefault();

            return discussion.UserId;
        }
    }
}
