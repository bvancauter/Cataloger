namespace Cataloger.Api.Features.Books.Authors.Models {
    public class AuthorUpdateModel {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
