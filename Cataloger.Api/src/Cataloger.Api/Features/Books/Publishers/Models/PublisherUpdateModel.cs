namespace Cataloger.Api.Features.Books.Publishers.Models {
    public class PublisherUpdateModel {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
