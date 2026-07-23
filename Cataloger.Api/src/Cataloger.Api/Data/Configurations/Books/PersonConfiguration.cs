using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations.Books {
    public class PersonConfiguration : IEntityTypeConfiguration<PersonEntity> {
        public void Configure(EntityTypeBuilder<PersonEntity> builder) {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => new {
                x.LastName,
                x.FirstName
            });
        }
    }
}
