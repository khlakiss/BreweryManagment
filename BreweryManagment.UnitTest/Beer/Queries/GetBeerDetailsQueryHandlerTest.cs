using AutoMapper;
using BreweryManagment.Application.Features.Beer.Queries.GetBeerDetails;
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

namespace BreweryManagment.UnitTest.Beer.Queries
{
    public class GetBeerDetailsQueryHandlerTest
    {
        private readonly Mock<IBeerRepository> _repository;

        public GetBeerDetailsQueryHandlerTest()
        {
            _repository = RepositoryMocks.MockBeerRepository();
        }

        [Fact]
        public async Task get_beer_details_success()
        {
            var handler = new GetBeerDetailsQueryHandler(_repository.Object);

            var request = new GetBeerDetailsQuery();

            var sut = await handler.Handle(request, CancellationToken.None);
            sut.ShouldBeOfType<GetBeerDetailsQueryResponse>();
            sut.Success.ShouldBeTrue();
            sut.BeerDetails.ShouldNotBeNull();
        }
    }
}
