using Cataloger.Api.Data;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.GetAll;

public class Endpoint(ApplicationDbContext applicationDbContext)
    : EndpointWithoutRequest<IEnumerable<Response>> {
    public override void Configure() {
        Get("/api/books/publishers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var publishers = await applicationDbContext.Publishers
            .AsNoTracking()
            .Select(p => new Response {
                Id = p.Id,
                Name = p.Name
            })
            .ToListAsync(ct);

        await Send.OkAsync(publishers, cancellation: ct);
    }
}