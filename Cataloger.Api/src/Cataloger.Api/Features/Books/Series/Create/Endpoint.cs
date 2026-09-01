using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Series.Models;
using Cataloger.Api.Features.Books.Series.Utils;
using Cataloger.Api.Routes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Cataloger.Api.Features.Books.Series.Create {
    public class Endpoint(ApplicationDbContext applicationDbContext)
        : Endpoint<SeriesCreateModel, SeriesFullModel> {

        public override void Configure() {
            Post(BookRoutes.Series);
            Description(x => x.WithTags(BookRoutes.SeriesTag));
            AllowAnonymous();
        }

        public override async Task HandleAsync(SeriesCreateModel model, CancellationToken ct) {
            var exists = await applicationDbContext.Series
                .AnyAsync(s => s.Name == model.Name, ct);

            if (exists) {
                AddError(r => r.Name, "Series already exists.");
                await Send.ErrorsAsync(cancellation: ct);
                return;
            }
            var entity = SeriesMapper.ToEntity(model);
            applicationDbContext.Series.Add(entity);
            await applicationDbContext.SaveChangesAsync(ct);
            await Send.CreatedAtAsync<Get.Endpoint>(
                new { id = entity.Id },
                SeriesMapper.ToFullModel(entity),
                cancellation: ct
            );
        }
    }
}
