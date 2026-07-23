namespace Cataloger.Api.Entities.Books {
    public class EditionEntity {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? TotalVolumes { get; set; }
        public Guid SeriesId { get; set; }
        public Guid PublisherId { get; set; }

        public SeriesEntity? Series { get; set; }
        public PublisherEntity? Publisher { get; set; }
        public ICollection<BookEntity>? Books { get; set; }
    }
}
