using FastEndpoints;
using FluentValidation;

namespace Cataloger.Api.Features.Books.Publishers.Models.Validators {
    public class PublisherCreateValidator : Validator<PublisherCreateModel> {
        public PublisherCreateValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Publisher's name is required!")
                .MaximumLength(255)
                .WithMessage("Publisher's name cannot exceed 255 characters!");
        }
    }
}
