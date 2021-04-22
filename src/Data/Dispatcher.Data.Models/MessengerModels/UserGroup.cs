namespace Dispatcher.Data.Models.MessengerModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class UserGroup : BaseDeletableModel<int>
    {
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
