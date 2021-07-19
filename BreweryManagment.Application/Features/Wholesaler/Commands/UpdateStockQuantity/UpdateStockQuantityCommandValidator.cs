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

        }
    }
}
