using Cataloger.Api.Data;
using Cataloger.Api.Entities.Books;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Get {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<Request, Response> {

        public override void Configure() {
            Get(BookRoutes.Publishers + "/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct) {
            var publisher = await applicationDbContext.Publishers
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == req.Id, ct);

            if (publisher is null) {
                await Send.NotFoundAsync(ct);
            } else {
                await Send.OkAsync(ToResponse(publisher), ct);
            }
        }

        private static Response ToResponse(PublisherEntity entity) => new() {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
