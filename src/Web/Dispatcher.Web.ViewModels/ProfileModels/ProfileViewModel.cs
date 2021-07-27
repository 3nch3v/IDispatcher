namespace Dispatcher.Web.ViewModels.ProfileModels
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models;
    using Dispatcher.Data.Models.Dtos;
    using Dispatcher.Data.Models.UserInfoModels;
    using Dispatcher.Services.Mapping;

    using static Dispatcher.Common.GlobalConstants.User;

    public class ProfileViewModel : IMapFrom<ApplicationUser>, IMapFrom<ProfileDataDto>, IMapFrom<ProfilePicture>
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public string Education { get; set; }

        public string CompanyName { get; set; }

        public string Interests { get; set; }

        public string Contacts { get; set; }

        public string WebsiteUrl { get; set; }

        public string GithubUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<ProfileCustomersReviewsViewModel> CumstomerReviews { get; set; }

        public virtual ICollection<ProfileAdvertisementsViewModel> Advertisements { get; set; }

        public virtual ICollection<ProfileProjectsViewModel> Projects { get; set; }

        public virtual ICollection<ProfileForumDiscussionsViewModel> Discussions { get; set; }

        public virtual ICollection<ProfileBlogsViewModel> Blogs { get; set; }

        public virtual ICollection<ProfileJobsViewModel> Jobs { get; set; }
    }
}
