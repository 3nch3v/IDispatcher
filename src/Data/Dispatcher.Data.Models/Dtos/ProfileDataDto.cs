namespace Dispatcher.Data.Models.Dtos
{
    using System.Collections.Generic;

    public class ProfileDataDto
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Education { get; set; }

        public string ComponyName { get; set; }

        public string Interests { get; set; }

        public string Contacts { get; set; }

        public string WebsiteUrl { get; set; }

        public string GithubUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public virtual ICollection<ProfileCustomersReviewsDto> CumstomerReviews { get; set; }

        public ICollection<ProfilePicturesDto> ProfilePictures { get; set; }

        public virtual ICollection<ProfileAdvertisementsDto> Advertisements { get; set; }

        public virtual ICollection<ProfileProjectsDto> Projects { get; set; }

        public virtual ICollection<ProfileForumDiscussionsDto> Discussions { get; set; }

        public virtual ICollection<ProfileBlogDtos> Blogs { get; set; }

        public virtual ICollection<ProfileJobsDto> Jobs { get; set; }
    }
}
