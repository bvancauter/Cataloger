using Cataloger.Api.Entities.Books;
using Cataloger.Api.Features.Books.Authors.Models;

namespace Cataloger.Api.Features.Books.Authors.Utils {
    public static class AuthorMapper {
        public static AuthorListModel ToListModel(PersonEntity entity) => new() {
            Id = entity.Id,
            FullName = entity.FullName
        };

        public static AuthorFullModel ToFullModel(PersonEntity entity) => new() {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            FullName = entity.FullName
        };

        public static PersonEntity ToEntity(AuthorCreateModel model) => new() {
            FirstName = model.FirstName,
            LastName = model.LastName
        };
    }
}
