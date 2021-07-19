using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.Commands.DeleteBeer
{
    public class DeleteBeerCommand : IRequest<DeleteBeerCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
