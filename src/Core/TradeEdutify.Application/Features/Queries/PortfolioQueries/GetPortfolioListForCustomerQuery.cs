using MediatR;
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