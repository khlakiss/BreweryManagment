using BreweryManagment.Application.Features.Wholesaler.DTOs;
using BreweryManagment.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.Queries.RequestQuote
{
    public class RequestQuoteCommandResponse : BaseResponse
    {
        public RequestQuoteResponseDto QuoteResponse { get; set; }

        public RequestQuoteCommandResponse()
        {
            QuoteResponse = new RequestQuoteResponseDto();
        }
    }
}
