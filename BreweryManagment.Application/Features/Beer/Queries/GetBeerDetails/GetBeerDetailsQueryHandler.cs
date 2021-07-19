using AutoMapper;
using BreweryManagment.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreweryManagment.Application.Features.Beer.Queries.GetBeerDetails
{
    public class GetBeerDetailsQueryHandler : IRequestHandler<GetBeerDetailsQuery, GetBeerDetailsQueryResponse>
    {
        private readonly IBeerRepository _repository;

        public GetBeerDetailsQueryHandler(IBeerRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBeerDetailsQueryResponse> Handle(GetBeerDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetBeerDetailsQueryResponse();

            try
            {
                var beerDetails = await _repository.GetBeersDetails();
                if (beerDetails == null || beerDetails.Count == 0)
                {
                    response.Success = false;
                    response.Message = "Something Went Wrong";
                }

                response.BeerDetails = beerDetails;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
