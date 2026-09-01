using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Series.Models;
using Cataloger.Api.Features.Books.Series.Utils;
using Cataloger.Api.Features.Common.Models;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Series.GetAll {
    public class Endpoint(ApplicationDbContext applicationDbContext)
    : Endpoint<PagedRequest, PagedResponse<SeriesListModel>> {
        public override void Configure() {
            Get(BookRoutes.Series);
            Description(x => x.WithTags(BookRoutes.SeriesTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(PagedRequest request, CancellationToken ct) {
            var query = applicationDbContext.Series
                .AsNoTracking();

            query = request.Descending
                ? query.OrderByDescending(s => s.Name)
                : query.OrderBy(s => s.Name);

            var totalItems = await query.CountAsync(ct);

            var series = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(ct);

            var totalPages = (int) Math.Ceiling(totalItems / (double) request.PageSize);

            var response = new PagedResponse<SeriesListModel> {
                Items = series
                    .Select(SeriesMapper.ToListModel)
                    .ToList(),
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };

            await Send.OkAsync(response, ct);
        }
    }
}
