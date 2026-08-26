using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Authors.Models;
using Cataloger.Api.Features.Books.Authors.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Authors.Get {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : EndpointWithoutRequest<AuthorFullModel> {

        public override void Configure() {
            Get(BookRoutes.Authors + "/{id:guid}");
            Description(x => x.WithTags(BookRoutes.AuthorsTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct) {
            Guid id = Route<Guid>("id");
            var author = await applicationDbContext.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, ct);

            if (author is null) {
                await Send.NotFoundAsync(ct);
                return;
            }
            await Send.OkAsync(AuthorMapper.ToFullModel(author), ct);
        }
    }
}
