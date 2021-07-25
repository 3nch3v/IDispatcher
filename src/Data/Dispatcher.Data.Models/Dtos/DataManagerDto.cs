namespace Dispatcher.Data.Models.Dtos
{
    using System.Collections.Generic;

    public class DataManagerDto
    {
        public string Id { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Projects { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Advertisements { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Discussions { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Blogs { get; set; }

        public virtual ICollection<DataManagerCollectionsDto> Jobs { get; set; }
    }
}
