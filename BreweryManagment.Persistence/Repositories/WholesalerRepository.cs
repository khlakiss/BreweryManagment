using BreweryManagment.Application.Features.Wholesaler.DTOs;
using BreweryManagment.Application.Persistence;
using BreweryManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagment.Persistence.Repositories
{
    public class WholesalerRepository : IWholesalerRepository
    {
        private readonly BreweryDBContext _context;

        public WholesalerRepository(BreweryDBContext context)
        {
            _context = context;
        }

        public async Task<WholesalerBeer> AddAsync(WholesalerBeer entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.WholesalerBeer.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(WholesalerBeer entity)
        {
            WholesalerBeer wholesalerBeer = await _context.WholesalerBeer.FirstOrDefaultAsync(wb => wb.BeerId == entity.BeerId && wb.WholesalerId == entity.WholesalerId);
            if (wholesalerBeer == null)
                return;
            wholesalerBeer.StockQuantity = entity.StockQuantity;
            await _context.SaveChangesAsync();
        }

        public async Task<RequestQuoteResponseDto> RequestQuote(RequestQuoteDto request)
        {
            RequestQuoteResponseDto result = new RequestQuoteResponseDto();

            decimal Price = 0;
            decimal TotalPrice = 0;
            decimal Discount = 0;
            int TotalQuantity = 0;
            List<QuoteDetailsDto> AvailableItems = new List<QuoteDetailsDto>();
            List<QuoteDetailsDto> MissingItems = new List<QuoteDetailsDto>();
            List<QuoteDetailsDto> NotInStockItems = new List<QuoteDetailsDto>();

            if (request.WholesalerId == null)
                return null;

            if (request.QuoteDetails.Count <= 0)
                return null;

            foreach (var item in request.QuoteDetails)
            {
                WholesalerBeer wholesalerBeer = await _context.WholesalerBeer.FirstOrDefaultAsync(wb => wb.BeerId == item.BeerId && wb.WholesalerId == request.WholesalerId);
                if (wholesalerBeer != null)
                {
                    if (item.Quantity > wholesalerBeer.StockQuantity)
                    {
                        NotInStockItems.Add(item);
                        continue;
                    }

                    Beer beer = await _context.Beer.FirstOrDefaultAsync(b => b.Id == item.BeerId);
                    Price = Price + (beer.Price.Value * item.Quantity);
                    TotalQuantity = TotalQuantity + item.Quantity;

                    AvailableItems.Add(item);
                }
                else
                {
                    MissingItems.Add(item);
                    continue;
                }
            }

            if (TotalQuantity > 10)
            {
                Discount = (Price * 10) / 100;

                if (TotalQuantity > 20)
                    Discount = (Price * 20) / 100;
            }

            TotalPrice = Price - Discount;

            result = new RequestQuoteResponseDto()
            {
                NotInStockItems = NotInStockItems,
                AvailableItems = AvailableItems,
                MissingItems = MissingItems,
                Discount = Discount,
                Price = Price,
                TotalPrice = TotalPrice
            };

            return result;
        }
    }
}
