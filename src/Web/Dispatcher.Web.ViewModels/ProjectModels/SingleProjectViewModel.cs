namespace Dispatcher.Web.ViewModels.ProjectModels
{
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;
    using Ganss.XSS;

    public class SingleProjectViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string UserRole { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}
