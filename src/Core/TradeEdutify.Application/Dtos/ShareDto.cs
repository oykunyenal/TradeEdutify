using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Dtos
{
    public record ShareDto
    {
        public ShareDto()
        {
            this.TransactionDtoList = new List<TransactionDto>();
            this.PortfolioDtoList = new List<PortfolioDto>();
        }
        public long ShareID { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public DateTimeOffset LastUpdateDate { get; set; }
        public List<TransactionDto>? TransactionDtoList { get; set; }
        public List<PortfolioDto>? PortfolioDtoList { get; set; }
    }
}
