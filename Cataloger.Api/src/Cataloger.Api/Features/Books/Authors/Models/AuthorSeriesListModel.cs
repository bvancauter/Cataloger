namespace Cataloger.Api.Features.Books.Authors.Models {
    public class AuthorSeriesListModel {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
