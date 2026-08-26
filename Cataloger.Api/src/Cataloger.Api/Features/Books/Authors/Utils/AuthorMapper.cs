using Cataloger.Api.Entities.Books;
using Cataloger.Api.Features.Books.Authors.Models;

namespace Cataloger.Api.Features.Books.Authors.Utils {
    public static class AuthorMapper {
        public static AuthorListModel ToListModel(PersonEntity entity) => new() {
            Id = entity.Id,
            FullName = entity.FullName
        };
    }
}
