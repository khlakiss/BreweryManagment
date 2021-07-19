using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.DTOs
{
    public class BeerDto
    {
        public Guid Id { get; set; }

        public Guid BreweryId { get; set; }

        public string Name { get; set; }

        public decimal AlcoholPercentage { get; set; }

        public decimal Price { get; set; }
    }
}
