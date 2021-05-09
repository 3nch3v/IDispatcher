namespace Dispatcher.Web.ViewModels.JobModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class SigleJobViewModel : IMapFrom<Job>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string JobBody { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public string Contact { get; set; }

        public string LogoUrl { get; set; }

        public string UserId { get; set; }
    }
}
