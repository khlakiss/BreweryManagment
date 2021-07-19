using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.DTOs
{
    public class RequestQuoteResponseDto
    {
        public List<QuoteDetailsDto> AvailableItems { get; set; }

        public List<QuoteDetailsDto> NotInStockItems { get; set; }

        public List<QuoteDetailsDto> MissingItems { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public RequestQuoteResponseDto()
        {
            AvailableItems = new List<QuoteDetailsDto>();
            MissingItems = new List<QuoteDetailsDto>();
        }
    }
}
