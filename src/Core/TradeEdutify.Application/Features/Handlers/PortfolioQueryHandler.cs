using MediatR;
using TradeEdutify.Application.Features.Queries.PortfolioQueries;
using TradeEdutify.Application.Interfaces.Repositories;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.Application.Features.Handlers
{
    public class PortfolioQueryHandler : IRequestHandler<GetPortfolioListForCustomerQuery, ApiServiceResponse>
    {
        private readonly IPortfolioRepository portfolioRepository;
        private ApiServiceResponse apiServiceResponse;

        public PortfolioQueryHandler(IPortfolioRepository portfolioRepository)
        {
            this.portfolioRepository = portfolioRepository;
            apiServiceResponse = new ApiServiceResponse();
        }

        public async Task<ApiServiceResponse> Handle(GetPortfolioListForCustomerQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Username))
            {
                throw new ArgumentNullException(nameof(request.Username), "GetPortfolioListForCustomerQuery Handle -> Username in request can not be null");
            }

            var portfolioListForUser = await portfolioRepository.GetPortfolioListForUser(request.Username.Replace(" ", ""));

            if (portfolioListForUser is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "User does not have portfolio",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            apiServiceResponse = new ApiServiceResponse
            {
                Message = "",
                Result = true,
                Object = portfolioListForUser
            };

            return Task.FromResult(apiServiceResponse).Result;

            throw new NotImplementedException();
        }
    }
}