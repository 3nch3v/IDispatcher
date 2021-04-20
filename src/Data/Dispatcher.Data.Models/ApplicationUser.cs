// ReSharper disable VirtualMemberCallInConstructor
namespace Dispatcher.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;
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
            this.Аdvertisements = new HashSet<Аdvertisement>(); 
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [MaxLength(2048)]
        public string ProfilePictureUrl { get; set; }

        [MaxLength(100)]
        public string Education { get; set; }

        [MaxLength(500)]
        public string Interests { get; set; }

        [MaxLength(2000)]
        public string Contacts { get; set; }

        [MaxLength(2048)]
        public string GitHubUrl { get; set; }

        [MaxLength(2048)]
        public string LinkedInUrl { get; set; }

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

        public virtual ICollection<Аdvertisement> Аdvertisements { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
