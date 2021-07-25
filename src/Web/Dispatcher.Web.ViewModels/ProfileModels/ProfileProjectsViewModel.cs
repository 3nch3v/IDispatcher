namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfileProjectsViewModel : IMapFrom<Project>, IMapFrom<ProfileProjectsDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserRole { get; set; }

        public string Url { get; set; }
    }
}
