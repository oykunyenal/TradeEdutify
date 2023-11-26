using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Features.Queries.PortfolioQueries;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.Application.Features.Handlers
{
    public class PortfolioQueryHandler : IRequestHandler<GetPortfolioListForCustomerQuery, ApiServiceResponse>
    {
        public Task<ApiServiceResponse> Handle(GetPortfolioListForCustomerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
