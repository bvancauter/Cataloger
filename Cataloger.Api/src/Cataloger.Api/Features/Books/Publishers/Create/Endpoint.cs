using Cataloger.Api.Data;
using Cataloger.Api.Entities.Books;
using Cataloger.Api.Features.Books.Publishers.Models;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Create {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<PublisherSaveModel, PublisherFullModel> {

        public override void Configure() {
            Post(BookRoutes.Publishers);
            AllowAnonymous();
        }

        public override async Task HandleAsync(PublisherSaveModel model, CancellationToken ct) {
            var exists = await applicationDbContext.Publishers
                .AnyAsync(p => p.Name == model.Name, ct);

            if (exists) {
                AddError(r => r.Name, "Publisher already exists.");
                await Send.ErrorsAsync(cancellation: ct);
            } else {
                var entity = ToEntity(model);
                applicationDbContext.Publishers.Add(entity);
                await applicationDbContext.SaveChangesAsync(ct);
                await Send.CreatedAtAsync<Get.Endpoint>(
                    new { id = entity.Id },
                    ToResponse(entity),
                    cancellation: ct
                );
            }
        }

        private static PublisherEntity ToEntity(PublisherSaveModel model) => new() {
            Name = model.Name.Trim()
        };

        private static PublisherFullModel ToResponse(PublisherEntity entity) => new() {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
