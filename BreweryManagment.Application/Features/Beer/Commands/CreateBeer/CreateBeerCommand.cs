using BreweryManagment.Application.Features.Beer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.Commands.CreateBeer
{
    public class CreateBeerCommand : IRequest<CreateBeerCommandResponse>
    {
        public BeerDto Beer { get; set; }
    }
}
