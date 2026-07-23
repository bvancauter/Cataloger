namespace Cataloger.Api.Entities.Books {
    public class SeriesEntity {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<EditionEntity>? Editions { get; set; }
    }
}
