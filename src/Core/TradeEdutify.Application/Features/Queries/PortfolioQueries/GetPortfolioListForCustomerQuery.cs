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
        public string Username { get; set; }
        public GetPortfolioListForCustomerQuery(string Username)
        {
            this.Username = Username;
        }
    }
}
