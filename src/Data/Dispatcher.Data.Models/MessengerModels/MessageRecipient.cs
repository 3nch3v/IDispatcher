namespace Dispatcher.Data.Models.MessengerModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class MessageRecipient
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Message))]
        public int MessageId { get; set; }

        public virtual Message Message { get; set; }

        [ForeignKey(nameof(UserGroup))]
        public int? UserGroupId { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
