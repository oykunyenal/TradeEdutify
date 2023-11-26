using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.Application.Features.Queries.PortfolioQueries
{
    public class GetPortfolioListForCustomerQuery : IRequest<ApiServiceResponse>
    {
        public long UserID { get; set; }
        public GetPortfolioListForCustomerQuery(long UserID)
        {
            this.UserID = UserID;
        }
    }
}
