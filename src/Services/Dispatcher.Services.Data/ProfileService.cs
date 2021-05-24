namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.ProfileModels;

    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<CustomerReview> commentsRepository;

        public ProfileService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<CustomerReview> commentsRepository)
        {
            this.usersRepository = usersRepository;
            this.commentsRepository = commentsRepository;
        }

        public T GetUserById<T>(string id)
        {
            var user = this.usersRepository.AllAsNoTracking()
                .Where(u => u.Id == id)
                .To<T>()
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<T> GetComments<T>(string id)
        {
            var comments = this.commentsRepository.All()
                .Where(x => x.UserId == id)
                .OrderBy(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return comments;
        }

        public async Task CommentAsync(string appraiserId, CommentInputModel input)
        {
            var comment = AutoMapperConfig.MapperInstance.Map<CustomerReview>(input);
            comment.AppraiserId = appraiserId;
            comment.UserId = input.UserId;

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
