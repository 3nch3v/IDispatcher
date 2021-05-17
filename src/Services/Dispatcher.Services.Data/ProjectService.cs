namespace Dispatcher.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dispatcher.Data.Common.Repositories;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Data.Contracts;
    using Dispatcher.Services.Mapping;
    using Dispatcher.Web.ViewModels.ProjectModels;

    public class ProjectService : IProjectService
    {
        private readonly IDeletableEntityRepository<Project> projectRepository;

        public ProjectService(IDeletableEntityRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task AddProjectAsync<T>(T input, string id)
        {
            var project = AutoMapperConfig.MapperInstance.Map<Project>(input);
            project.UserId = id;

            await this.projectRepository.AddAsync(project);
            await this.projectRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var project = this.projectRepository.All().FirstOrDefault(p => p.Id == id);
            this.projectRepository.Delete(project);
            await this.projectRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllProjects<T>()
        {
            var projects = this.projectRepository.AllAsNoTracking()
                .OrderByDescending(p => p.CreatedOn)
                .To<T>()
                .ToList();

            return projects;
        }

        public T GetProject<T>(int id)
        {
            var project = this.projectRepository.AllAsNoTracking()
                .Where(p => p.Id == id)
                .To<T>()
                .FirstOrDefault();

            return project;
        }

        public async Task UpdateAsync(ProjectInputmodel input, int id)
        {
            var project = this.projectRepository.All().FirstOrDefault(p => p.Id == id);
            project.Name = input.Name;
            project.Description = input.Description;
            project.Url = input.Url;
            project.UserRole = input.UserRole;

            await this.projectRepository.SaveChangesAsync();
        }
    }
}
