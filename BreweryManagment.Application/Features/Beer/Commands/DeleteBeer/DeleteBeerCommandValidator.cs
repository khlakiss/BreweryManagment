using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.Commands.DeleteBeer
{
    public class DeleteBeerCommandValidator : AbstractValidator<DeleteBeerCommand>
    {
        public DeleteBeerCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }
    }
}
