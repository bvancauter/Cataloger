using FastEndpoints;
using FluentValidation;

namespace Cataloger.Api.Features.Books.Publishers.Models.Validators {
    public class PublisherUpdateValidator : Validator<PublisherUpdateModel> {
        public PublisherUpdateValidator() {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Publisher's ID is required!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Publisher's name is required!")
                .MaximumLength(255)
                .WithMessage("Publisher's name cannot exceed 255 characters!");
        }
    }
}
