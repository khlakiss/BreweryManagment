using BreweryManagment.Application.Features.Wholesaler.DTOs;
using BreweryManagment.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Commands.UpdateStockQuantity
{
    public class UpdateStockQuantityCommandResponse: BaseResponse
    {
        public WholesaleBeerDto WholesaleBeer { get; set; }

        public UpdateStockQuantityCommandResponse()
        {
            WholesaleBeer = new WholesaleBeerDto();
        }
    }
}
