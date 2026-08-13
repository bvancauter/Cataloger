using FastEndpoints;
using FluentValidation;

namespace Cataloger.Api.Features.Common.Models.Validators {
    public class PagedRequestValidator : Validator<PagedRequest> {
        public PagedRequestValidator() {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);
        }
    }
}
