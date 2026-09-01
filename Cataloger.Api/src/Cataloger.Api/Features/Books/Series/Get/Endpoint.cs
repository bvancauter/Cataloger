using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Series.Models;
using Cataloger.Api.Features.Books.Series.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Series.Get {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : EndpointWithoutRequest<SeriesFullModel> {

        public override void Configure() {
            Get(BookRoutes.Series + "/{id:guid}");
            Description(x => x.WithTags(BookRoutes.SeriesTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct) {
            Guid id = Route<Guid>("id");
            var series = await applicationDbContext.Series
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id, ct);

            if (series is null) {
                await Send.NotFoundAsync(cancellation: ct);
                return;
            }
            await Send.OkAsync(SeriesMapper.ToFullModel(series), cancellation: ct);
        }
    }
}
