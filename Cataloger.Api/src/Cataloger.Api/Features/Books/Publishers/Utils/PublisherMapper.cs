using Cataloger.Api.Entities.Books;
using Cataloger.Api.Features.Books.Publishers.Models;

namespace Cataloger.Api.Features.Books.Publishers.Utils {
    public static class PublisherMapper {
        public static PublisherListModel ToListModel(PublisherEntity entity) => new() {
            Id = entity.Id,
            Name = entity.Name
        };

        public static PublisherFullModel ToFullModel(PublisherEntity entity) => new() {
            Id = entity.Id,
            Name = entity.Name
        };

        public static PublisherEntity ToEntity(PublisherCreateModel model) => new() {
            Name = model.Name.Trim()
        };

        public static void UpdateEntity(PublisherEntity entity, PublisherUpdateModel model) {
            entity.Name = model.Name.Trim();
        }
    }
}
