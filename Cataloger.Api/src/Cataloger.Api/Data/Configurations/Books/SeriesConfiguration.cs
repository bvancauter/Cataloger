using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations.Books {
    public class SeriesConfiguration : IEntityTypeConfiguration<SeriesEntity> {
        public void Configure(EntityTypeBuilder<SeriesEntity> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
