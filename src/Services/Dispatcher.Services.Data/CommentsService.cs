namespace Dispatcher.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync<T>(T input, string userId)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<Comment>(input);

            comment.UserId = userId;

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var commment = this.commentsRepository.All().FirstOrDefault(c => c.Id == id);

            this.commentsRepository.Delete(commment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public string GetCreatorId(int dataId)
        {
            var comment = this.commentsRepository
                .AllAsNoTracking()
                .Where(c => c.Id == dataId)
                .FirstOrDefault();

            return comment?.UserId;
        }
    }
}
