namespace Cataloger.Api.Entities.Books {
    public class PersonEntity {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<BookContributorEntity>? Books { get; set; }
    }
}
