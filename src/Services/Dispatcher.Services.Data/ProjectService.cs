namespace Dispatcher.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;

    public class ProjectService : IProjectService
    {
        private readonly IDeletableEntityRepository<Project> projectRepository;

        public ProjectService(IDeletableEntityRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task CreateAsync<T>(T input, string id)
        {
            var project = AutoMapperConfig.MapperInstance.Map<Project>(input);
            project.UserId = id;

            await this.projectRepository.AddAsync(project);
            await this.projectRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = this.projectRepository.All()
                .FirstOrDefault(p => p.Id == id);

            this.projectRepository.Delete(project);
            await this.projectRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var project = this.projectRepository.AllAsNoTracking()
                .Where(p => p.Id == id)
                .To<T>()
                .FirstOrDefault();

            return project;
        }

        public async Task UpdateAsync<T>(T input, int id)
        {
            var updatedProject = AutoMapperConfig.MapperInstance.Map<Project>(input);
            var project = this.projectRepository.All().FirstOrDefault(p => p.Id == id);

            project.Name = updatedProject.Name;
            project.Description = updatedProject.Description;
            project.Url = updatedProject.Url;
            project.UserRole = updatedProject.UserRole;

            await this.projectRepository.SaveChangesAsync();
        }
    }
}
