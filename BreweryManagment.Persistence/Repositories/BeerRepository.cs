using BreweryManagment.Application.Features.Beer.DTOs;
using BreweryManagment.Application.Persistence;
using BreweryManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagment.Persistence.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BreweryDBContext _context;

        public BeerRepository(BreweryDBContext context)
        {
            _context = context;
        }

        public async Task<Beer> GetByIdAsync(Guid id)
        {
            return await _context.Set<Beer>().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<BeerDetailsDto>> GetBeersDetails()
        {
            List<BeerDetailsDto> result = new List<BeerDetailsDto>();

            //Get all beers from db
            var beers = await _context.Set<Beer>().ToListAsync();
            if (beers == null)
                return null;

            //Loop them to add their details
            foreach (var item in beers)
            {
                BeerDetailsDto beerDetails = new BeerDetailsDto();
                beerDetails.Beer = item.Name;

                //Get the brewery Name
                var brewery = await _context.Set<Brewery>().FirstOrDefaultAsync(br => br.Id == item.BreweryId);
                if (brewery == null)
                    return null;
                beerDetails.Brewery = brewery.Name;

                //Get all the wholselers
                var wholesalerBeerIds = await _context.Set<WholesalerBeer>().Where(wb => wb.BeerId == item.Id).Select(wb => wb.WholesalerId).ToListAsync();
                if (wholesalerBeerIds != null)
                {
                    var wholesaler = await _context.Set<Wholesaler>().Where(w => wholesalerBeerIds.Contains(w.Id)).Select(w => w.Name).ToListAsync();
                    if (wholesaler != null)
                        beerDetails.Wholesalers = wholesaler;
                }

                result.Add(beerDetails);
            }

            return result;
        }

        public async Task<Beer> AddAsync(Beer entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Beer.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
