using BreweryManagment.Application.Features.Wholesaler.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Commands.CreateSales
{
    public class CreateSalesCommand : IRequest<CreateSalesCommandResponse>
    {
        public WholesaleBeerDto WholesaleBeer { get; set; }
    }
}
