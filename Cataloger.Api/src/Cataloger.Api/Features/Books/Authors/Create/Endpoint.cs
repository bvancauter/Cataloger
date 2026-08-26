using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Authors.Models;
using Cataloger.Api.Features.Books.Authors.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Authors.Create {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<AuthorCreateModel, AuthorFullModel> {

        public override void Configure() {
            Post(BookRoutes.Authors);
            Description(x => x.WithTags(BookRoutes.AuthorsTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(AuthorCreateModel model, CancellationToken ct) {
            var exists = await applicationDbContext.Persons
                .AnyAsync(p => p.FirstName == model.FirstName && p.LastName == model.LastName, ct);

            if (exists) {
                AddError(r => r.FirstName, "Author already exists.");
                await Send.ErrorsAsync(cancellation: ct);
                return;
            }
            var entity = AuthorMapper.ToEntity(model);
            applicationDbContext.Persons.Add(entity);
            await applicationDbContext.SaveChangesAsync(ct);
            await Send.CreatedAtAsync<Get.Endpoint>(
                new { id = entity.Id },
                AuthorMapper.ToFullModel(entity),
                cancellation: ct
            );
        }
    }
}
