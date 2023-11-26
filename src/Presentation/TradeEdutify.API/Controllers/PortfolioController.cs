using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeEdutify.Application.Features.Queries.PortfolioQueries;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly IMediator mediator;
        private ApiServiceResponse apiServiceResponse;
        private string userClaim;

        public PortfolioController(IMediator mediator)
        {
            this.mediator = mediator;
            apiServiceResponse = new ApiServiceResponse();
        }

        [HttpGet("GetPortfolioListForCustomer")]
        public async Task<IActionResult> GetPortfolioListForCustomer()
        {
            userClaim = HttpContext.User.Claims.FirstOrDefault().Value;

            var GetPortfolioListForCustomerQuery = new GetPortfolioListForCustomerQuery(userClaim);

            apiServiceResponse = await mediator.Send(GetPortfolioListForCustomerQuery);

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }
    }
}
