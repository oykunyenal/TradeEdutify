using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Application.Dtos
{
    public record PortfolioDto
    {
        public Guid PortfolioID { get; set; }
        public DateTimeOffset OperationDate { get; set; }
        public Guid UserID { get; set; }
        public Guid ShareID { get; set; }
    }
}
