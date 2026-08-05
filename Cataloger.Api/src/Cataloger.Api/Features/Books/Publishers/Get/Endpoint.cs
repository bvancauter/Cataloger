using Cataloger.Api.Data;
using Cataloger.Api.Entities.Books;
using Cataloger.Api.Features.Books.Publishers.Models;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Get {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : EndpointWithoutRequest<PublisherFullModel> {

        public override void Configure() {
            Get(BookRoutes.Publishers + "/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct) {
            Guid id = Route<Guid>("id");
            var publisher = await applicationDbContext.Publishers
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (publisher is null) {
                await Send.NotFoundAsync(ct);
            } else {
                await Send.OkAsync(ToResponse(publisher), ct);
            }
        }

        private static PublisherFullModel ToResponse(PublisherEntity entity) => new() {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
