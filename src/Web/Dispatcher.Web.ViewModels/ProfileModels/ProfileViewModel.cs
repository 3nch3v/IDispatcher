namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    public class ProfileViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public string Education { get; set; }

        public string ComponyName { get; set; }

        public string Interests { get; set; }

        public string Contacts { get; set; }

        public string WebsiteUrl { get; set; }

        public string GithubUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public ICollection<ProfilePicture> ProfilePictures { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public virtual ICollection<CustomerReview> CumstomerReviews { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
