using Cataloger.Api.Data;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Delete {
    public class Endpoint(ApplicationDbContext applicationDbContext) 
        : Endpoint<Request> {

        public override void Configure() {
            Delete(BookRoutes.Publishers + "/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct) {
            var publisher = await applicationDbContext.Publishers
                .FirstOrDefaultAsync(p => p.Id == req.Id, ct);

            if(publisher is null) {
                await Send.NotFoundAsync(ct);
            }
            else {
                applicationDbContext.Publishers.Remove(publisher);
                await applicationDbContext.SaveChangesAsync(ct);
                await Send.NoContentAsync(ct);
            }
        }
    }
}
