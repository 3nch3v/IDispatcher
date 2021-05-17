namespace Dispatcher.Web.ViewModels.ProjectModels
{
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class EditProjectInputModul : ProjectInputmodel, IMapFrom<Project>
    {
        public int Id { get; set; }
    }
}
