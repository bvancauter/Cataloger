namespace Cataloger.Api.Entities {
    public class CollectionItemEntity {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateOnly? ReleaseDate { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public decimal? PurchasePrice { get; set; }
        public bool IsFavorite { get; set; }
        public decimal? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
