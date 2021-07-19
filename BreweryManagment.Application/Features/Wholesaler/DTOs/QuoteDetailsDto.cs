using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.DTOs
{
    public class QuoteDetailsDto
    {
        public Guid BeerId { get; set; }

        public int Quantity { get; set; }
    }
}
