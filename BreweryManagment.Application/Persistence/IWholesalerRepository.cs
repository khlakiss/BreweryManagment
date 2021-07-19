using BreweryManagment.Application.Features.Wholesaler.DTOs;
using BreweryManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagment.Application.Persistence
{
    public interface IWholesalerRepository
    {
        Task<bool> CheckIfSaleExist(WholesalerBeer entity);

        Task<bool> CheckDuplicateOrder(List<QuoteDetailsDto> order);

        Task<WholesalerBeer> AddAsync(WholesalerBeer entity);

        Task UpdateAsync(WholesalerBeer entity);

        Task<RequestQuoteResponseDto> RequestQuote(RequestQuoteDto request);
    }
}
