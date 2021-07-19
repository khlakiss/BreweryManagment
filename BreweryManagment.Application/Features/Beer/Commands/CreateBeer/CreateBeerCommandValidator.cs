using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.Commands.CreateBeer
{
    public class CreateBeerCommandValidator : AbstractValidator<CreateBeerCommand>
    {
        public CreateBeerCommandValidator()
        {
            RuleFor(p => p.Beer.Name)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.Beer.BreweryId)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.Beer.AlcoholPercentage)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.Beer.Price)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }
    }
}
