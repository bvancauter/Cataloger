using Cataloger.Api.Data;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Authors.Delete {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : EndpointWithoutRequest {

        public override void Configure() {
            Delete(BookRoutes.Authors + "/{id:guid}");
            Description(x => x.WithTags(BookRoutes.AuthorsTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct) {
            Guid id = Route<Guid>("id");
            var author = await applicationDbContext.Persons
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (author is null) {
                await Send.NotFoundAsync(ct);
                return;
            }
            applicationDbContext.Persons.Remove(author);
            await applicationDbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
