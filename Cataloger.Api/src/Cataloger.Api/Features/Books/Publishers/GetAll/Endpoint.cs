using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Publishers.Models;
using Cataloger.Api.Features.Books.Publishers.Utils;
using Cataloger.Api.Features.Common.Models;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Publishers.GetAll;

public class Endpoint(ApplicationDbContext applicationDbContext)
    : Endpoint<PagedRequest, PagedResponse<PublisherListModel>> {
    public override void Configure() {
        Get(BookRoutes.Publishers);
        AllowAnonymous();
    }

    public override async Task HandleAsync(PagedRequest request, CancellationToken ct) {
        var query = applicationDbContext.Publishers
            .AsNoTracking()
            .OrderBy(x => x.Name);

        var totalItems = await query.CountAsync(ct);

        var publishers = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct);

        var totalPages = (int) Math.Ceiling(totalItems / (double) request.PageSize);

        var response = new PagedResponse<PublisherListModel> {
            Items = publishers
                .Select(PublisherMapper.ToListModel)
                .ToList(),
            Page = request.Page,
            PageSize = request.PageSize,
            TotalItems = totalItems,
            TotalPages = totalPages
        };

        await Send.OkAsync(response, ct);
    }
}
