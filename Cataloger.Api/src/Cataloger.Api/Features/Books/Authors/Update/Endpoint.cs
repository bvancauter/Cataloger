using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Authors.Models;
using Cataloger.Api.Features.Books.Authors.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Authors.Update {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<AuthorUpdateModel> {
        public override void Configure() {
            Put(BookRoutes.Authors + "/{id:guid}");
            Description(x => x.WithTags(BookRoutes.AuthorsTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(AuthorUpdateModel model, CancellationToken ct) {
            var author = await applicationDbContext.Persons
                .FirstOrDefaultAsync(x => x.Id == model.Id, ct);

            if (author is null) {
                await Send.NotFoundAsync(ct);
                return;
            }

            AuthorMapper.UpdateEntity(author, model);

            var exists = await applicationDbContext.Persons
                .AnyAsync(p => p.FirstName == model.FirstName && p.LastName == model.LastName, ct);

            if (exists) {
                AddError(r => r.FirstName, "Author already exists.");
                await Send.ErrorsAsync(cancellation: ct);
                return;
            }

            await applicationDbContext.SaveChangesAsync(ct);

            await Send.NoContentAsync(ct);
        }
    }
}
