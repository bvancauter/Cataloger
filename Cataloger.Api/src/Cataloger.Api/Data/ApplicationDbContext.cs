using Cataloger.Api.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<BookEntity> Books => Set<BookEntity>();
        public DbSet<SeriesEntity> Series => Set<SeriesEntity>();
        public DbSet<EditionEntity> Editions => Set<EditionEntity>();
        public DbSet<PublisherEntity> Publishers => Set<PublisherEntity>();
        public DbSet<PersonEntity> Persons => Set<PersonEntity>();
        public DbSet<BookContributorEntity> BookContributors => Set<BookContributorEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}