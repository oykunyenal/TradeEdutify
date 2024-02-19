using AutoMapper;
using TradeEdutify.Application.Dtos;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Mappings
{
    public class TransactionMapping : Profile
    {
        public TransactionMapping()
        {
            CreateMap<Transaction, TransactionDto>()
               .ReverseMap();
        }
    }
}