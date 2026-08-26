using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Authors.Models;
using Cataloger.Api.Features.Books.Authors.Utils;
using Cataloger.Api.Features.Common.Models;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Authors.GetAll {
    public class Endpoint(ApplicationDbContext applicationDbContext)
    : Endpoint<PagedRequest, PagedResponse<AuthorListModel>> {
        public override void Configure() {
            Get(BookRoutes.Authors);
            AllowAnonymous();
        }

        public override async Task HandleAsync(PagedRequest request, CancellationToken ct) {
            var query = applicationDbContext.Persons
                .AsNoTracking();

            query = request.Descending
                ? query.OrderByDescending(p => p.FirstName).ThenByDescending(p => p.LastName)
                : query.OrderBy(p => p.FirstName).ThenBy(p => p.LastName);

            var totalItems = await query.CountAsync(ct);

            var authors = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(ct);

            var totalPages = (int) Math.Ceiling(totalItems / (double) request.PageSize);

            var response = new PagedResponse<AuthorListModel> {
                Items = authors
                    .Select(AuthorMapper.ToListModel)
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
