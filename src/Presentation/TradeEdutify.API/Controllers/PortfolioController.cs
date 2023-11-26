using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeEdutify.Application.Features.Queries.PortfolioQueries;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator mediator;
        private ApiServiceResponse apiServiceResponse;

        public PortfolioController(IMediator mediator, ApiServiceResponse apiServiceResponse)
        {
            this.mediator = mediator;
            this.apiServiceResponse = apiServiceResponse;
        }

        [HttpGet("GetPortfolioListForCustomer/{UserID}")]
        public async Task<IActionResult> GetPortfolioListForCustomer(long UserID)
        {
            var GetPortfolioListForCustomerQuery = new GetPortfolioListForCustomerQuery(UserID);

            apiServiceResponse = await mediator.Send(GetPortfolioListForCustomerQuery);

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }
    }
}
