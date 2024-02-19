using AutoMapper;
using TradeEdutify.Application.Dtos;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Mappings
{
    public class PortfolioMapping : Profile
    {
        public PortfolioMapping()
        {
            CreateMap<Portfolio, PortfolioDto>()
                .ReverseMap();
        }
    }
}