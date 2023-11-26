using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
