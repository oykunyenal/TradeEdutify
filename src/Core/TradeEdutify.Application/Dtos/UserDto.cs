using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Application.Dtos
{
    public record UserDto
    {

        public UserDto()
        {
            this.TransactionDtoList = new List<TransactionDto>();
            this.PortfolioDtoList = new List<PortfolioDto>();
        }

        public Guid UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<TransactionDto>? TransactionDtoList { get; set; }
        public List<PortfolioDto>? PortfolioDtoList { get; set; }
    }
}
