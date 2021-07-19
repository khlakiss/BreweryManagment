using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Commands.UpdateStockQuantity
{
    public class UpdateStockQuantityCommandValidator : AbstractValidator<UpdateStockQuantityCommand>
    {
        public UpdateStockQuantityCommandValidator()
        {
            RuleFor(p => p.WholesaleBeer.BeerId)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.WholesaleBeer.WholesalerId)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.WholesaleBeer.Quantity)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();
        }
    }
}
