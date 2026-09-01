using FastEndpoints;
using FluentValidation;

namespace Cataloger.Api.Features.Books.Series.Models.Validators {
    public class SeriesCreateValidator : Validator<SeriesCreateModel> {
        public SeriesCreateValidator() {
            RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Publisher's name is required!")
                    .MaximumLength(255)
                    .WithMessage("Publisher's name cannot exceed 255 characters!");
        }
    }
}
