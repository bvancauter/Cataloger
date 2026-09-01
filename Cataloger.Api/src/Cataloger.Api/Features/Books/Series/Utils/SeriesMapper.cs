using Cataloger.Api.Entities.Books;
using Cataloger.Api.Features.Books.Series.Models;

namespace Cataloger.Api.Features.Books.Series.Utils {
    public class SeriesMapper {
        public static SeriesEntity ToEntity(SeriesCreateModel model) => new() {
            Name = model.Name.Trim()
        };

        public static SeriesFullModel ToFullModel(SeriesEntity entity) => new() {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
