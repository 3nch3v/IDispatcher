namespace Dispatcher.Data.Models.UserInfoModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dispatcher.Data.Common.Models;

    using static Dispatcher.Common.GlobalConstants.File;

    public class ProfilePicture : BaseDeletableModel<string>
    {
        public ProfilePicture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(FileMaxLenght)]
        public string FilePath { get; set; }

        [Required]
        [MaxLength(ExtensionMaxLenght)]
        public string Extension { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
