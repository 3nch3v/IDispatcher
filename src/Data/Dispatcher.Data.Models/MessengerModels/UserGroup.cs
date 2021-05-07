namespace Dispatcher.Data.Models.MessengerModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class UserGroup : BaseDeletableModel<int>
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
