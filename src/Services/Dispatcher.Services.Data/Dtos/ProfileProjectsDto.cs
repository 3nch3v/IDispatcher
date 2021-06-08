namespace Dispatcher.Services.Data.Dtos
{
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfileProjectsDto : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserRole { get; set; }

        public string Url { get; set; }
    }
}
