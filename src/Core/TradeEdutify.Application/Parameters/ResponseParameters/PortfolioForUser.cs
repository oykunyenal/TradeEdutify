using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Application.Parameters.ResponseParameters
{
    public class PortfolioForUser
    {
        public string Username { get; set; } = string.Empty;
        public string ShareSymbol { get; set; } = string.Empty;
        public string ShareRate { get; set; } = string.Empty;
    }
}
