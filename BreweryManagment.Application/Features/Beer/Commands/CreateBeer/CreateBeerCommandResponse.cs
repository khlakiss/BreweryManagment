using BreweryManagment.Application.Features.Beer.DTOs;
using BreweryManagment.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.Commands.CreateBeer
{
    public class CreateBeerCommandResponse : BaseResponse
    {
        public BeerDto Beer { get; set; }

        public CreateBeerCommandResponse()
        {
            Beer = new BeerDto();
        }
    }
}
