namespace Cataloger.Api.Entities.Books {
    public class PublisherEntity {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<EditionEntity> Editions { get; set; } = [];
    }
}
