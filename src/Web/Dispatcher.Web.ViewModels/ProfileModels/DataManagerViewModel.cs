namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class DataManagerViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
