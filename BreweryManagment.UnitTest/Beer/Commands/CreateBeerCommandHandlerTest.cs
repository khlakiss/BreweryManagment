using AutoMapper;
using BreweryManagment.Application.Features.Beer.Commands.CreateBeer;
using BreweryManagment.Application.Persistence;
using BreweryManagment.Application.Profiles;
using BreweryManagment.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BreweryManagment.UnitTest.Beer.Commands
{
    public class CreateBeerCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBeerRepository> _repository;

        public CreateBeerCommandHandlerTest()
        {
            _repository = RepositoryMocks.MockBeerRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task create_beer_success()
        {
            var handler = new CreateBeerCommandHandler(_mapper, _repository.Object);

            var request = new CreateBeerCommand
            {
                Beer = new Application.Features.Beer.DTOs.BeerDto()
                {
                    AlcoholPercentage = 0.2m,
                    BreweryId = Guid.NewGuid(),
                    Name = "UnitTest",
                    Price = 23
                }
            };

            var sut = await handler.Handle(request, CancellationToken.None);
            sut.ShouldBeOfType<CreateBeerCommandResponse>();
            sut.Success.ShouldBeTrue();
            sut.Beer.ShouldNotBeNull();
        }
    }
}
