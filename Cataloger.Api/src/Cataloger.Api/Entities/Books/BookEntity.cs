namespace Cataloger.Api.Entities.Books {
    public class BookEntity : CollectionItemEntity {
        public int Volume { get; set; }
        public string? Synopsis { get; set; }
        public string? Isbn { get; set; }
        public BookType Type { get; set; }
        public BookStatus Status { get; set; }
        public BookCondition Condition { get; set; }
        public Guid EditionId { get; set; }

        public EditionEntity? Edition { get; set; }
        public ICollection<BookContributorEntity>? Contributors { get; set; }
    }

    public enum BookType {
        Novel,
        Manga,
        Comic,
        GraphicNovel,
        LightNovel,
        Artbook,
        Other
    }

    public enum BookStatus {
        Wishlist,
        Owned,
        Reading,
        Completed,
        OnHold,
        Dropped
    }

    public enum BookCondition {
        New,
        LikeNew,
        Good,
        Fair,
        Poor
    }
}
