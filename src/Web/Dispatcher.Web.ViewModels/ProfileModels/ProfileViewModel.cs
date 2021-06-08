namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models;
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

        public virtual ICollection<ProfileCustomersReviewsViewModel> CumstomerReviews { get; set; }

        public ICollection<ProfilePicturesCollectionViewModel> ProfilePictures { get; set; }

        public virtual ICollection<ProfileAdvertisementsViewModel> Advertisements { get; set; }

        public virtual ICollection<ProfileProjectsViewModel> Projects { get; set; }

        public virtual ICollection<ProfileForumDiscussionsViewModel> Discussions { get; set; }

        public virtual ICollection<ProfileBlogsViewModel> Blogs { get; set; }

        public virtual ICollection<ProfileJobsViewModel> Jobs { get; set; }
    }
}
