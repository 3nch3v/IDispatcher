namespace Dispatcher.Web.ViewModels.JobModels
{
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Services.Mapping;

    public class EditJobInputModel : JobInputModel, IMapFrom<Job>, IMapTo<Job>
    {
        public int Id { get; set; }
    }
}
