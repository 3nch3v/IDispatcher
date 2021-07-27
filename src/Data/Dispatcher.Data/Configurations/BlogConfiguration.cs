namespace Dispatcher.Data.Configurations
{
    using Dispatcher.Data.Models.BlogModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
                .HasOne(b => b.BlogImage)
                .WithOne(i => i.Blog)
                .HasForeignKey<BlogImage>(b => b.BlogId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
