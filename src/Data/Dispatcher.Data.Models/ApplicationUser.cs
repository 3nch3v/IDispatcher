namespace Dispatcher.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;
    using Dispatcher.Data.Models.AdvertisementModels;
    using Dispatcher.Data.Models.BlogModels;
    using Dispatcher.Data.Models.ForumModels;
    using Dispatcher.Data.Models.JobModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Microsoft.AspNetCore.Identity;

    using static Dispatcher.Common.GlobalConstants.Data;
    using static Dispatcher.Common.GlobalConstants.User;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Projects = new HashSet<Project>();
            this.CumstomerReviews = new HashSet<CustomerReview>();
            this.Advertisements = new HashSet<Advertisement>();
            this.Jobs = new HashSet<Job>();
            this.Discussions = new HashSet<Discussion>();
            this.Posts = new HashSet<Comment>();
            this.Blogs = new HashSet<Blog>();
        }

        [MaxLength(NameMaxLenght)]
        public string FirstName { get; set; }

        [MaxLength(NameMaxLenght)]
        public string LastName { get; set; }

        [MaxLength(EducationMaxLenght)]
        public string Education { get; set; }

        [MaxLength(NameMaxLenght)]
        public string CompanyName { get; set; }

        [MaxLength(InterestMaxLenght)]
        public string Interest { get; set; }

        [MaxLength(ContactMaxLenght)]
        public string Contact { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string WebsiteUrl { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string GithubUrl { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string FacebookUrl { get; set; }

        [MaxLength(UrlMaxLenght)]
        public string InstagramUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string ProfilePictureId { get; set; }

        public virtual ProfilePicture ProfilePicture { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<CustomerReview> CumstomerReviews { get; set; }

        [InverseProperty("Appraiser")]
        public virtual ICollection<CustomerReview> Appraisers { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }

        public virtual ICollection<Comment> Posts { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
