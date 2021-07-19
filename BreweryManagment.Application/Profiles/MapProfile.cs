using AutoMapper;
using BreweryManagment.Application.Features.Beer.Commands.CreateBeer;
using BreweryManagment.Application.Features.Beer.DTOs;
using BreweryManagment.Application.Features.Wholesaler.DTOs;
using BreweryManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagment.Application.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BeerDto, Beer>().ReverseMap();
            CreateMap<WholesaleBeerDto, WholesalerBeer>().ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.Quantity)).ReverseMap();
        }
    }
}
