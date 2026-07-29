using Cataloger.Api.Data;
using Cataloger.Api.Entities.Books;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.Create {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<Request, Response> {

        public override void Configure() {
            Post(BookRoutes.Publishers);
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request request, CancellationToken ct) {
            var exists = await applicationDbContext.Publishers
                .AnyAsync(p => p.Name == request.Name, ct);

            if (exists) {
                AddError(r => r.Name, "Publisher already exists.");
                await Send.ErrorsAsync(cancellation: ct);
            } else {
                var entity = ToEntity(request);
                applicationDbContext.Publishers.Add(entity);
                await applicationDbContext.SaveChangesAsync(ct);
                await Send.OkAsync(ToResponse(entity), cancellation: ct); // need to be modified to send a created code
            }
        }

        private static PublisherEntity ToEntity(Request request) => new() {
            Name = request.Name.Trim()
        };

        private static Response ToResponse(PublisherEntity entity) => new() {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
