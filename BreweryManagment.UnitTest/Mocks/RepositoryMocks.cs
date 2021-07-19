using BreweryManagment.Application.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IBeerRepository> MockBeerRepository()
        {
            var mockRepoistory = new Mock<IBeerRepository>();
            return mockRepoistory;
        }

        public static Mock<IWholesalerRepository> MockWholesalerRepository()
        {
            var mockRepoistory = new Mock<IWholesalerRepository>();
            return mockRepoistory;
        }
    }
}
