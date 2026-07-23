using Cataloger.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations {
    public class CollectionItemConfiguration : IEntityTypeConfiguration<CollectionItemEntity> {
        public void Configure(EntityTypeBuilder<CollectionItemEntity> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Rating)
                .HasPrecision(2, 1);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_CollectionItem_Rating",
                    "\"Rating\" IS NULL OR (\"Rating\" >= 0 AND \"Rating\" <= 5)"
                );
            });
        }
    }
}
