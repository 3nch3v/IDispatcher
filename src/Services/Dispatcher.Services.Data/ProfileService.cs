namespace Dispatcher.Services.Data
{
    using System.Linq;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ProfileService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public T GetUserById<T>(string id)
        {
            var user = this.usersRepository.AllAsNoTracking()
                .Where(u => u.Id == id)
                .To<T>()
                .FirstOrDefault();

            return user;
        }
    }
}
