using BreweryManagment.Application.Features.Beer.Commands.CreateBeer;
using BreweryManagment.Application.Features.Beer.Commands.DeleteBeer;
using BreweryManagment.Application.Features.Beer.Queries.GetBeerDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreweryManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<GetBeerDetailsQueryResponse> GetBeerDetails()
        {
            var result = await _mediator.Send(new GetBeerDetailsQuery());
            return result; 
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<CreateBeerCommandResponse> CreateBeer([FromBody] CreateBeerCommand request) => await _mediator.Send(request);

        [HttpPost]
        [Route("[action]")]
        public async Task<DeleteBeerCommandResponse> DeleteBeer([FromBody] DeleteBeerCommand request) => await _mediator.Send(request);
    }
}
