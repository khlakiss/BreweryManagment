using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.DTOs
{
    public class RequestQuoteDto
    {
        public Guid WholesalerId { get; set; }

        public List<QuoteDetailsDto> QuoteDetails { get; set; }

        public RequestQuoteDto()
        {
            QuoteDetails = new List<QuoteDetailsDto>();
        }
    }
}
