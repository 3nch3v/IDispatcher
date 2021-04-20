namespace Dispatcher.Data.Configurations
{
    using Dispatcher.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment
                .HasKey(k => new { k.ApplicationUserId, k.АdvertisementId });
        }
    }
}
