using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cataloger.Api.Data.Configurations.Books {
    public class SeriesContributorConfiguration : IEntityTypeConfiguration<SeriesContributorEntity> {
        public void Configure(EntityTypeBuilder<SeriesContributorEntity> builder) {
            builder.HasKey(x => new {
                x.SeriesId,
                x.PersonId,
                x.Role
            });

            builder.HasOne(x => x.Series)
                .WithMany(x => x.Contributors)
                .HasForeignKey(x => x.SeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.SeriesContributors)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
