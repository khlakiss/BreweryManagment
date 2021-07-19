using AutoMapper;
using BreweryManagment.Application.Features.Wholesaler.Commands.CreateSales;
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
    public class CreateSalesCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWholesalerRepository> _repository;

        public CreateSalesCommandHandlerTest()
        {
            _repository = RepositoryMocks.MockWholesalerRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task create_sales_success()
        {
            var handler = new CreateSalesCommandHandler(_mapper, _repository.Object);

            var request = new CreateSalesCommand()
            {
                WholesaleBeer = new Application.Features.Wholesaler.DTOs.WholesaleBeerDto()
                {
                    BeerId = Guid.NewGuid(),
                    Quantity = 21,
                    WholesalerId = Guid.NewGuid()
                }
            };

            var sut = await handler.Handle(request, CancellationToken.None);
            sut.ShouldBeOfType<CreateSalesCommandResponse>();
            sut.Success.ShouldBeTrue();
            sut.WholesaleBeer.ShouldNotBeNull();
        }
    }
}
