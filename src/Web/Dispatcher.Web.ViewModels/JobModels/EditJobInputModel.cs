namespace Dispatcher.Web.ViewModels.JobModels
{
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Services.Mapping;

    public class EditJobInputModel : BaseJobInputModel, IMapFrom<Job>
    {
        public int Id { get; set; }
    }
}
