namespace Dispatcher.Data.Models.MessengerModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MessageRecipient
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Message))]
        public int MessageId { get; set; }

        public virtual Message Message { get; set; }

        [ForeignKey(nameof(UserGroup))]
        public int? UserGroupId { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
