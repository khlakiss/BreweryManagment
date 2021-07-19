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
        private readonly IMapper _mapper;

        public GetBeerDetailsQueryHandler(IMapper mapper, IBeerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetBeerDetailsQueryResponse> Handle(GetBeerDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetBeerDetailsQueryResponse();

            if (response.Success)
            {
                response.BeerDetails = await _repository.GetBeersDetails();
            }

            return response;
        }
    }
}
