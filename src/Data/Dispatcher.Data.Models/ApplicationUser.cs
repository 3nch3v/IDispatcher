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
    using Dispatcher.Data.Models.MessengerModels;
    using Dispatcher.Data.Models.UserInfoModels;
    using Microsoft.AspNetCore.Identity;

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
            this.UsersGroups = new HashSet<UserGroup>();
            this.Messages = new HashSet<Message>();
            this.MessagesRecipients = new HashSet<MessageRecipient>();
            this.Jobs = new HashSet<Job>();
            this.Discussions = new HashSet<Discussion>();
            this.Posts = new HashSet<Comment>();
            this.Blogs = new HashSet<Blog>();
            this.ProfilePictures = new HashSet<ProfilePicture>();
        }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Education { get; set; }

        // CompanyName !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [StringLength(50, MinimumLength = 2)]
        public string ComponyName { get; set; }

        [StringLength(1000, MinimumLength = 2)]
        public string Interests { get; set; }

        [StringLength(200, MinimumLength = 6)]
        public string Contacts { get; set; }

        [MaxLength(2048)]
        public string WebsiteUrl { get; set; }

        [MaxLength(2048)]
        public string GithubUrl { get; set; }

        [MaxLength(2048)]
        public string FacebookUrl { get; set; }

        [MaxLength(2048)]
        public string InstagramUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<CustomerReview> CumstomerReviews { get; set; }

        [InverseProperty("Appraiser")]
        public virtual ICollection<CustomerReview> Appraisers { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public virtual ICollection<UserGroup> UsersGroups { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<MessageRecipient> MessagesRecipients { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }

        public virtual ICollection<Comment> Posts { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

        public ICollection<ProfilePicture> ProfilePictures { get; set; }
    }
}
