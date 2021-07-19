using BreweryManagment.Application.Features.Wholesaler.Commands.CreateSales;
using BreweryManagment.Application.Features.Wholesaler.Commands.UpdateStockQuantity;
using BreweryManagment.Application.Features.Wholesaler.Queries.RequestQuote;
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
    public class WholesaleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WholesaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<CreateSalesCommandResponse> CreateSale([FromBody] CreateSalesCommand request) => await _mediator.Send(request);

        [HttpPost]
        [Route("[action]")]
        public async Task<UpdateStockQuantityCommandResponse> UpdateStockQuantity([FromBody] UpdateStockQuantityCommand request) => await _mediator.Send(request);

        [HttpPost]
        [Route("[action]")]
        public async Task<RequestQuoteCommandResponse> RequestQuote([FromBody] RequestQuoteCommand request) => await _mediator.Send(request);
    }
}
