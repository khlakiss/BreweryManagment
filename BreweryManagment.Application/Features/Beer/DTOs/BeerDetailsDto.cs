using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.DTOs
{
    public class BeerDetailsDto
    {
        public string Brewery { get; set; }

        public string Beer { get; set; }

        public List<string> Wholesalers { get; set; }
    }
}
