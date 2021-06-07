namespace Dispatcher.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> postsRepository;

        public CommentService(IDeletableEntityRepository<Comment> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task CreateAsync<T>(T input)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<Comment>(input);

            await this.postsRepository.AddAsync(comment);
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var commment = this.postsRepository.All().FirstOrDefault(c => c.Id == id);
            this.postsRepository.Delete(commment);
            await this.postsRepository.SaveChangesAsync();
        }
    }
}
