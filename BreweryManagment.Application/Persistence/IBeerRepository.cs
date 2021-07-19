using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BreweryManagment.Application.Features.Beer.DTOs;
using BreweryManagment.Domain.Entities;

namespace BreweryManagment.Application.Persistence
{
    public interface IBeerRepository
    {
        Task<Beer> GetByIdAsync(Guid id);

        Task<List<BeerDetailsDto>> GetBeersDetails();

        Task<Beer> AddAsync(Beer entity);

        Task DeleteAsync(Guid id);
    }
}
