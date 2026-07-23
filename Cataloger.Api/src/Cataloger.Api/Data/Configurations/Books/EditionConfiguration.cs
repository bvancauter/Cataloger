using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations.Books {
    public class EditionConfiguration : IEntityTypeConfiguration<EditionEntity> {
        public void Configure(EntityTypeBuilder<EditionEntity> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(x => x.Series)
                .WithMany(x => x.Editions)
                .HasForeignKey(x => x.SeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Publisher)
                .WithMany(x => x.Editions)
                .HasForeignKey(x => x.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
