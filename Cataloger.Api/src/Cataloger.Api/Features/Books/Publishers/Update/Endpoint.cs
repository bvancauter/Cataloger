using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Publishers.Models;
using Cataloger.Api.Features.Books.Publishers.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Update {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<PublisherUpdateModel> {
        public override void Configure() {
            Put(BookRoutes.Publishers + "/{id:guid}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(PublisherUpdateModel model, CancellationToken ct) {
            var publisher = await applicationDbContext.Publishers
                .FirstOrDefaultAsync(x => x.Id == model.Id, ct);

            if (publisher is null) {
                await Send.NotFoundAsync(ct);
                return;
            }

            PublisherMapper.UpdateEntity(publisher, model);

            var exists = await applicationDbContext.Publishers
                .AnyAsync(p => p.Name == publisher.Name, ct);

            if (exists) {
                AddError(r => r.Name, "Publisher already exists.");
                await Send.ErrorsAsync(cancellation: ct);
                return;
            }

            await applicationDbContext.SaveChangesAsync(ct);

            await Send.NoContentAsync(ct);
        }
    }
}
