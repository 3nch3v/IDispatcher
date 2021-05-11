namespace Dispatcher.Web.ViewModels.ViewComponents
{
    using System;

    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class SingelRandomJobViewModel : IMapFrom<Job>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string JobBody { get; set; }

        public string Location { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
