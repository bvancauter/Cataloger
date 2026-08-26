using FastEndpoints;
using FluentValidation;

namespace Cataloger.Api.Features.Books.Authors.Models.Validators {
    public class AuthorCreateValidator : Validator<AuthorCreateModel> {
        public AuthorCreateValidator() {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Author's first name is required!")
                .MaximumLength(255)
                .WithMessage("Author's first name cannot exceed 255 characters!");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Author's last name is required!")
                .MaximumLength(255)
                .WithMessage("Author's last name cannot exceed 255 characters!");
        }
    }
}
