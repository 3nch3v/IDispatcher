namespace Dispatcher.Data.Models.UserInfoModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    public class ProfilePicture : BaseDeletableModel<string>
    {
        public ProfilePicture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(2048)]
        public string FilePath { get; set; }

        [Required]
        [MaxLength(2048)]
        public string PhysicalFilePath { get; set; }

        [Required]
        [MaxLength(5)]
        public string Extension { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
