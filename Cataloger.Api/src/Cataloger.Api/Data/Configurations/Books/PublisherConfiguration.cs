using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations.Books {
    public class PublisherConfiguration : IEntityTypeConfiguration<PublisherEntity> {
        public void Configure(EntityTypeBuilder<PublisherEntity> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
