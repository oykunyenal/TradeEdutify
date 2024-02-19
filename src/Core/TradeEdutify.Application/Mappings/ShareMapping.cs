using AutoMapper;
using TradeEdutify.Application.Dtos;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Mappings
{
    public class ShareMapping : Profile
    {
        public ShareMapping()
        {
            CreateMap<Share, ShareDto>()
               .ForMember(dest => dest.PortfolioDtoList, opt => opt.MapFrom(src => src.Portfolios != null ? src.Portfolios.ToList() : new List<Portfolio>()))
               .ForMember(dest => dest.TransactionDtoList, opt => opt.MapFrom(src => src.Transactions != null ? src.Transactions.ToList() : new List<Transaction>()))
               .ReverseMap();
        }
    }
}