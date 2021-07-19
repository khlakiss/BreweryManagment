using AutoMapper;
using BreweryManagment.Application.Features.Beer.Commands.DeleteBeer;
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

namespace BreweryManagment.UnitTest.Beer.Commands
{
    public class DeleteBeerCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBeerRepository> _repository;

        public DeleteBeerCommandHandlerTest()
        {
            _repository = RepositoryMocks.MockBeerRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task delete_beer_success()
        {
            var handler = new DeleteBeerCommandHandler(_mapper, _repository.Object);

            var request = new DeleteBeerCommand
            {
                Id = Guid.NewGuid()
            };

            var sut = await handler.Handle(request, CancellationToken.None);
            sut.ShouldBeOfType<DeleteBeerCommandResponse>();
            sut.Success.ShouldBeTrue();
        }
    }
}
