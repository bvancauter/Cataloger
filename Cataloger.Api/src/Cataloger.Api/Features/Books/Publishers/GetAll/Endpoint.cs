using Cataloger.Api.Data;
using Cataloger.Api.Entities.Books;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.GetAll;

public class Endpoint(ApplicationDbContext applicationDbContext)
    : EndpointWithoutRequest<IEnumerable<Response>> {
    public override void Configure() {
        Get(BookRoutes.Publishers);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var publishers = await applicationDbContext.Publishers
            .AsNoTracking()
            .ToListAsync(ct);

        await Send.OkAsync(publishers.Select(ToResponse), ct);
    }

    private static Response ToResponse(PublisherEntity entity) => new() {
        Id = entity.Id,
        Name = entity.Name
    };
}