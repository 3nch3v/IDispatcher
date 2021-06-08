namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    public class DataManagerViewModel
    {
        public string Id { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Projects { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Advertisements { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Discussions { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Blogs { get; set; }

        public virtual ICollection<DataManagerCollectionsViewModel> Jobs { get; set; }
    }
}
