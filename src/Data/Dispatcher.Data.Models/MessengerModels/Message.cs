namespace Dispatcher.Data.Models.MessengerModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Dispatcher.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(200)]
        public string Body { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
