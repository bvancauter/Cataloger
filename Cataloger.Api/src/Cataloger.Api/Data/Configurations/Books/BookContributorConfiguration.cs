using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations.Books {
    public class BookContributorConfiguration : IEntityTypeConfiguration<BookContributorEntity> {
        public void Configure(EntityTypeBuilder<BookContributorEntity> builder) {
            builder.HasKey(x => new
            {
                x.BookId,
                x.PersonId,
                x.Role
            });

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Contributors)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
