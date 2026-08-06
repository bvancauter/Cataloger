using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Publishers.Models;
using Cataloger.Api.Features.Books.Publishers.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.GetAll;

public class Endpoint(ApplicationDbContext applicationDbContext)
    : EndpointWithoutRequest<IEnumerable<PublisherListModel>> {
    public override void Configure() {
        Get(BookRoutes.Publishers);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var publishers = await applicationDbContext.Publishers
            .AsNoTracking()
            .ToListAsync(ct);

        await Send.OkAsync(publishers.Select(PublisherMapper.ToListModel), ct);
    }
}
