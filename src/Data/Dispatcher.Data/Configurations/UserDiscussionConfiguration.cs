namespace Dispatcher.Data.Configurations
{
    using Dispatcher.Data.Models.ForumModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserDiscussionConfiguration : IEntityTypeConfiguration<UserDiscussion>
    {
        public void Configure(EntityTypeBuilder<UserDiscussion> userDiscussion)
        {
            userDiscussion
                .HasKey(k => new { k.ApplicationUserId, k.DiscussionId });
        }
    }
}
