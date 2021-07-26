namespace Dispatcher.Data.Models.Dtos
{
    using System.Collections.Generic;

    using Dispatcher.Data.Models.UserInfoModels;

    public class ProfileDataDto
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Education { get; set; }

        public string CompanyName { get; set; }

        public string Interest { get; set; }

        public string Contact { get; set; }

        public string WebsiteUrl { get; set; }

        public string GithubUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public ProfilePicture ProfilePicture { get; set; }

        public virtual ICollection<ProfileCustomersReviewsDto> CumstomerReviews { get; set; }

        public virtual ICollection<ProfileAdvertisementsDto> Advertisements { get; set; }

        public virtual ICollection<ProfileProjectsDto> Projects { get; set; }

        public virtual ICollection<ProfileForumDiscussionsDto> Discussions { get; set; }

        public virtual ICollection<ProfileBlogDtos> Blogs { get; set; }

        public virtual ICollection<ProfileJobsDto> Jobs { get; set; }
    }
}
