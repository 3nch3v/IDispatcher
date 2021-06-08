namespace Dispatcher.Services.Data.Dtos
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models;
    using Dispatcher.Services.Mapping;

    public class DataManagerDto : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Projects { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Advertisements { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Discussions { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Blogs { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Jobs { get; set; }
    }
}
