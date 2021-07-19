using BreweryManagment.Application.Features.Wholesaler.DTOs;
using BreweryManagment.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Commands.CreateSales
{
    public class CreateSalesCommandResponse : BaseResponse
    {
        public WholesaleBeerDto WholesaleBeer { get; set; }

        public CreateSalesCommandResponse()
        {
            WholesaleBeer = new WholesaleBeerDto();
        }
    }
}
