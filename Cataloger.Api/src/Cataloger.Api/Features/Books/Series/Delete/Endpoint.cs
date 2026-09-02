using Cataloger.Api.Data;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Series.Delete {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : EndpointWithoutRequest {

        public override void Configure() {
            Delete(BookRoutes.Series + "/{id:guid}");
            Description(x => x.WithTags(BookRoutes.SeriesTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct) {
            Guid id = Route<Guid>("id");
            var series = await applicationDbContext.Series
                .FirstOrDefaultAsync(s => s.Id == id, ct);

            if (series is null) {
                await Send.NotFoundAsync(ct);
                return;
            }
            applicationDbContext.Series.Remove(series);
            await applicationDbContext.SaveChangesAsync(ct);
            await Send.NoContentAsync(ct);
        }
    }
}
