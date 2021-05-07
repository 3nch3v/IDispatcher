// ReSharper disable VirtualMemberCallInConstructor
namespace Dispatcher.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
            this.Comments = new HashSet<Comment>();
            this.UsersGroups = new HashSet<UserGroup>();
            this.Messages = new HashSet<Message>();
            this.MessagesRecipients = new HashSet<MessageRecipient>();
            this.Jobs = new HashSet<Job>();
            this.UserDiscussions = new HashSet<UserDiscussion>();
            this.Posts = new HashSet<Post>();
            this.Blogs = new HashSet<Blog>();
        }

        ////[Required]
        ////public string FirstName { get; set; }

        ////[Required]
        ////public string LastName { get; set; }

        ////[MaxLength(2048)]
        ////public string ProfilePictureUrl { get; set; }

        ////[MaxLength(200)]
        ////public string Education { get; set; }

        ////[MaxLength(1000)]
        ////public string Interests { get; set; }

        ////[MaxLength(2000)]
        ////public string Contacts { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<CustomerReview> CumstomerReviews { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserGroup> UsersGroups { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<MessageRecipient> MessagesRecipients { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public virtual ICollection<UserDiscussion> UserDiscussions { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
