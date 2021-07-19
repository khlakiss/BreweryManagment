using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Wholesaler.DTOs
{
    public class WholesaleBeerDto
    {
        public Guid Id { get; set; }

        public Guid WholesalerId { get; set; }

        public Guid BeerId { get; set; }

        public long Quantity { get; set; }
    }
}
