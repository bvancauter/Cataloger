using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations.Books {
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity> {
        public void Configure(EntityTypeBuilder<BookEntity> builder) {
            builder.Property(x => x.Isbn)
                .HasMaxLength(20);

            builder.Property(x => x.Synopsis)
                .HasMaxLength(5000);

            builder.HasOne(x => x.Edition)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.EditionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
