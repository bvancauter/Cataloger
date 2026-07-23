namespace Cataloger.Api.Entities.Books {
    public class BookContributorEntity {
        public Guid BookId { get; set; }
        public Guid PersonId { get; set; }
        public BookRole Role { get; set; }

        public BookEntity? Book { get; set; }
        public PersonEntity? Person { get; set; }
        
    }

    public enum BookRole {
        Writer,
        Artist
    }
}
