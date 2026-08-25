using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Publishers.Models;
using Cataloger.Api.Features.Books.Publishers.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Create {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<PublisherCreateModel, PublisherFullModel> {

        public override void Configure() {
            Post(BookRoutes.Publishers);
            AllowAnonymous();
        }

        public override async Task HandleAsync(PublisherCreateModel model, CancellationToken ct) {
            var exists = await applicationDbContext.Publishers
                .AnyAsync(p => p.Name == model.Name, ct);

            if (exists) {
                AddError(r => r.Name, "Publisher already exists.");
                await Send.ErrorsAsync(cancellation: ct);
                return;
            }
            var entity = PublisherMapper.ToEntity(model);
            applicationDbContext.Publishers.Add(entity);
            await applicationDbContext.SaveChangesAsync(ct);
            await Send.CreatedAtAsync<Get.Endpoint>(
                new { id = entity.Id },
                PublisherMapper.ToFullModel(entity),
                cancellation: ct
            );
        }
    }
}
