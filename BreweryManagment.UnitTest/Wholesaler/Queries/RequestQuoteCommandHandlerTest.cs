using AutoMapper;
using BreweryManagment.Application.Features.Wholesaler.Queries.RequestQuote;
using BreweryManagment.Application.Persistence;
using BreweryManagment.Application.Profiles;
using BreweryManagment.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BreweryManagment.UnitTest.Wholesaler.Queries
{
    public class RequestQuoteCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWholesalerRepository> _repository;

        public RequestQuoteCommandHandlerTest()
        {
            _repository = RepositoryMocks.MockWholesalerRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task request_quote_success()
        {
            var handler = new RequestQuoteCommandHandler(_mapper, _repository.Object);

            var request = new RequestQuoteCommand()
            {
               Quote = new Application.Features.Wholesaler.DTOs.RequestQuoteDto()
               {
                   WholesalerId = Guid.NewGuid(),
                   QuoteDetails = new List<Application.Features.Wholesaler.DTOs.QuoteDetailsDto>()
                   {
                       new Application.Features.Wholesaler.DTOs.QuoteDetailsDto()
                       {
                           BeerId = Guid.NewGuid(),
                           Quantity = 2
                       }
                   }
               }
            };

            var sut = await handler.Handle(request, CancellationToken.None);
            sut.ShouldBeOfType<RequestQuoteCommandResponse>();
            sut.Success.ShouldBeTrue();
            sut.QuoteResponse.ShouldNotBeNull();
        }
    }
}
