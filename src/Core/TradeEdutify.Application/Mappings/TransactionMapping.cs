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
    public class TransactionMapping : Profile
    {
        public TransactionMapping()
        {
             CreateMap<Transaction,TransactionDto>()
                .ReverseMap();
        }
    }
}
