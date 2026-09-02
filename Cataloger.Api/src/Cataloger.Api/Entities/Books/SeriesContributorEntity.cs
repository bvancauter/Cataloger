namespace Cataloger.Api.Entities.Books {
    public class SeriesContributorEntity {
        public Guid SeriesId { get; set; }
        public Guid PersonId { get; set; }
        public BookRole Role { get; set; }

        public SeriesEntity? Series { get; set; }
        public PersonEntity? Person { get; set; }

    }

    public enum BookRole {
        Writer,
        Artist
    }
}
