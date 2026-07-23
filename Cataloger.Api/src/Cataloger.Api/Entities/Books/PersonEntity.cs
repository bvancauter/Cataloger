namespace Cataloger.Api.Entities.Books {
    public class PersonEntity {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Pseudonym { get; set; }

        public ICollection<BookContributorEntity>? Books { get; set; }
    }
}
