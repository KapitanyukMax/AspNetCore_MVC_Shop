using DataAccess.Entities;
using FluentValidation;
using System;

namespace AspNetCore_MVC_Shop.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(i => i.Id).NotNull();
            RuleFor(i => i.Name).NotNull().MaximumLength(100);
            RuleFor(i => i.Price).GreaterThanOrEqualTo(0.0);
            RuleFor(i => i.Discount).InclusiveBetween(0.0, 100.0);
            RuleFor(i => i.Rating).InclusiveBetween(1, 10);
            RuleFor(i => i.Description).Length(10, 1000);
            RuleFor(i => i.ImagePath)
                .Must(ValidateUri)
                .WithMessage("{PropertyName} must be a valid URL address.");
        }

        public bool ValidateUri(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
                return true;

            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
