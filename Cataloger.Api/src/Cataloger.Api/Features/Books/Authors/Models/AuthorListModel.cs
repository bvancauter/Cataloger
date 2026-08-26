namespace Cataloger.Api.Features.Books.Authors.Models {
    public class AuthorListModel {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}
