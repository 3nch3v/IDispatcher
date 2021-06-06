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
        private readonly IProfileService profileService;

        public ForumService(
            IDeletableEntityRepository<Discussion> forumRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IProfileService profileService)
        {
            this.forumRepository = forumRepository;
            this.categoriesRepository = categoriesRepository;
            this.profileService = profileService;
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

        public T GetById<T>(int id)
        {
            var discussion = this.forumRepository.AllAsNoTracking()
                .Include(x => x.Votes)
                .Where(d => d.Id == id)
                .To<T>()
                .FirstOrDefault();

            return discussion;
        }

        public SingleForumDiscussionsViewModel GetDiscussion(int id)
        {
            var discussion = this.forumRepository.AllAsNoTracking()
                .Include(x => x.Votes)
                .Where(d => d.Id == id)
                .To<SingleForumDiscussionsViewModel>()
                .FirstOrDefault();

            this.LoadCommentsWithPicture(discussion);

            return discussion;
        }

        public IEnumerable<SingleForumDiscussionsViewModel> GetAllForumDiscussions(int page, int pageEntitiesCount, string category = null)
        {
            IEnumerable<SingleForumDiscussionsViewModel> discussions = null;

            if (string.IsNullOrEmpty(category))
            {
               discussions = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<SingleForumDiscussionsViewModel>()
               .ToList();
            }
            else if (!string.IsNullOrEmpty(category) && category != "unsolved")
            {
                discussions = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .Where(x => x.Category.Name == category)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<SingleForumDiscussionsViewModel>()
               .ToList();
            }
            else
            {
                discussions = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .Where(x => x.IsSolved == false)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<SingleForumDiscussionsViewModel>()
               .ToList();
            }

            foreach (var discussion in discussions)
            {
                this.LoadCommentsWithPicture(discussion);
            }

            return discussions;
        }

        public IEnumerable<T> GetCategories<T>()
        {
            var categories = this.categoriesRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return categories;
        }

        public int ForumDiscussionsCount()
        {
            return this.forumRepository.All().Count();
        }

        public int GetUnsolvedDiscussionsCount()
        {
            int unsolvedCount = this.forumRepository
                .AllAsNoTracking()
                .Where(d => d.IsSolved == false)
                .Count();

            return unsolvedCount;
        }

        public int GetDiscussionsCountPerCategory(string categoty)
        {
            return this.forumRepository.AllAsNoTracking()
                .Where(x => x.Category.Name == categoty)
                .Count();
        }

        private void LoadCommentsWithPicture(SingleForumDiscussionsViewModel discussion)
        {
            discussion.ProfilePicture = this.profileService.GetProfilePicturePath(discussion.UserId);
            var result = discussion.Posts.Select(x => new SinglePostViewModel
            {
                Id = x.Id,
                Content = x.Content,
                UserId = x.UserId,
                UserUsername = x.UserUsername,
                ProfilePicture = this.profileService.GetProfilePicturePath(x.UserId),
            });

            discussion.Posts = result;
        }
    }
}
