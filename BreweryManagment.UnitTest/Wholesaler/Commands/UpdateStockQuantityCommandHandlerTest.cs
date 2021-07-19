using AutoMapper;
using BreweryManagment.Application.Features.Wholesaler.Commands.UpdateStockQuantity;
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

namespace BreweryManagment.UnitTest.Wholesaler.Commands
{
    public class UpdateStockQuantityCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWholesalerRepository> _repository;

        public UpdateStockQuantityCommandHandlerTest()
        {
            _repository = RepositoryMocks.MockWholesalerRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task update_stock_success()
        {
            var handler = new UpdateStockQuantityCommandHandler(_mapper, _repository.Object);

            var request = new UpdateStockQuantityCommand()
            {
                WholesaleBeer = new Application.Features.Wholesaler.DTOs.WholesaleBeerDto()
                {
                    BeerId = Guid.NewGuid(),
                    Quantity = 21,
                    WholesalerId = Guid.NewGuid()
                }
            };

            var sut = await handler.Handle(request, CancellationToken.None);
            sut.ShouldBeOfType<UpdateStockQuantityCommandResponse>();
            sut.Success.ShouldBeTrue();
            sut.WholesaleBeer.ShouldNotBeNull();
        }
    }
}
