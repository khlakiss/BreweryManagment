using BreweryManagment.Application.Features.Beer.DTOs;
using BreweryManagment.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Features.Beer.Queries.GetBeerDetails
{
    public class GetBeerDetailsQueryResponse : BaseResponse
    {
        public List<BeerDetailsDto> BeerDetails { get; set; }

        public GetBeerDetailsQueryResponse()
        {
            BeerDetails = new List<BeerDetailsDto>();
        }
    }
}
