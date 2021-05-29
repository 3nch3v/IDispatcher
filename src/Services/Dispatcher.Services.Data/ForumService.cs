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
        private readonly IDeletableEntityRepository<Comment> postsRepository;
        private readonly IProfileService profileService;

        public ForumService(
            IDeletableEntityRepository<Discussion> forumRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Comment> postsRepository,
            IProfileService profileService)
        {
            this.forumRepository = forumRepository;
            this.categoriesRepository = categoriesRepository;
            this.postsRepository = postsRepository;
            this.profileService = profileService;
        }

        public async Task AddCommentAsync<T>(T input)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<Comment>(input);

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

        public T GetDiscussion<T>(int id)
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

            this.LoadProfilePictures(discussion);

            return discussion;
        }

        public IEnumerable<SingleForumDiscussionsViewModel> GetAllForumDiscussions(int page, int pageEntitiesCount, string category = null)
        {
            IEnumerable<SingleForumDiscussionsViewModel> forumPosts = null;

            if (string.IsNullOrEmpty(category))
            {
               forumPosts = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<SingleForumDiscussionsViewModel>()
               .ToList();
            }
            else if (!string.IsNullOrEmpty(category) && category != "unsolved")
            {
                forumPosts = this.forumRepository.AllAsNoTracking()
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
                forumPosts = this.forumRepository.AllAsNoTracking()
               .Include(x => x.Votes)
               .Where(x => x.IsSolved == false)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageEntitiesCount)
               .Take(pageEntitiesCount)
               .To<SingleForumDiscussionsViewModel>()
               .ToList();
            }

            foreach (var discussion in forumPosts)
            {
                this.LoadProfilePictures(discussion);
            }

            return forumPosts;
        }

        public IEnumerable<T> GetCategories<T>()
        {
            var categories = this.categoriesRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return categories;
        }

        public async Task EditDiscussionAsync(DiscussionInputModel input, int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            discussion.Title = input.Title;
            discussion.Description = input.Description;
            discussion.CategoryId = input.CategoryId;

            await this.forumRepository.SaveChangesAsync();
        }

        public async Task SetDiscussionToSolvedAsync(int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            discussion.IsSolved = true;
            await this.forumRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            var commment = this.postsRepository.All().FirstOrDefault(c => c.Id == id);
            this.postsRepository.Delete(commment);
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task DeleteDiscussionAsync(int id)
        {
            var discussion = this.forumRepository.All().FirstOrDefault(d => d.Id == id);
            this.forumRepository.Delete(discussion);
            await this.forumRepository.SaveChangesAsync();
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

        private void LoadProfilePictures(SingleForumDiscussionsViewModel discussion)
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
