namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Services.Mapping;

    public class DataManagerViewModel : IMapFrom<DataManagerDto>
    {
        public string Id { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Projects { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Advertisements { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Discussions { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Blogs { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Jobs { get; set; }
    }
}
