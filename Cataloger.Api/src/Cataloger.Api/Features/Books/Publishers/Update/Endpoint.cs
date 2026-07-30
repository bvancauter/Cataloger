using Cataloger.Api.Data;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Update {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<Request> {
        public override void Configure() {
            Put(BookRoutes.Publishers + "/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct) {
            var publisher = await applicationDbContext.Publishers
                .FirstOrDefaultAsync(x => x.Id == req.Id, ct);

            if (publisher is null) {
                await Send.NotFoundAsync(ct);
                return;
            }

            publisher.Name = req.Name.Trim();

            await applicationDbContext.SaveChangesAsync(ct);

            await Send.NoContentAsync(ct);
        }
    }
}
