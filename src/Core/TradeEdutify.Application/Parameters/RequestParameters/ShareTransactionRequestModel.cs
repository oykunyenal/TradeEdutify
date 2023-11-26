using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Application.Parameters.RequestParameters
{
    public class ShareTransactionRequestModel
    {
        public string Symbol { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
