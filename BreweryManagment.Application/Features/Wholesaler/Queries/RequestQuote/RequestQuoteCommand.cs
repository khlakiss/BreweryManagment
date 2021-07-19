using BreweryManagment.Application.Features.Wholesaler.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Queries.RequestQuote
{
    public class RequestQuoteCommand : IRequest<RequestQuoteCommandResponse>
    {
        public RequestQuoteDto Quote { get; set; }

        public RequestQuoteCommand()
        {
            Quote = new RequestQuoteDto();
        }
    }
}
