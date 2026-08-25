using Cataloger.Api.Data;
using Cataloger.Api.Features.Books.Publishers.Models;
using FastEndpoints;
using FluentValidation;

namespace Cataloger.Api.Features.Books.Publishers.Utils.Validators {
    public class PublisherCreateValidator : Validator<PublisherCreateModel> {
        private readonly ApplicationDbContext dbContext;

        public PublisherCreateValidator(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
