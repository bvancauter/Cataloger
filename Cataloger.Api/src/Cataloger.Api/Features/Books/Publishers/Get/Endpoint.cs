using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Publishers.Models;
using Cataloger.Api.Features.Books.Publishers.Utils;
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
                return;
            }
            await Send.OkAsync(PublisherMapper.ToFullModel(publisher), ct);
        }
    }
}
