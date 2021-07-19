using BreweryManagment.Application.Features.Wholesaler.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Commands.UpdateStockQuantity
{
    public class UpdateStockQuantityCommand : IRequest<UpdateStockQuantityCommandResponse>
    {
        public WholesaleBeerDto WholesaleBeer { get; set; }
    }
}
