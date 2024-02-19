using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradeEdutify.API.Controllers.Base;
using TradeEdutify.Application.Features.Queries.PortfolioQueries;

namespace TradeEdutify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PortfolioController : BaseController
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPortfolioListForCustomer")]
        public async Task<IActionResult> GetPortfolioListForCustomer()
        {
            userClaim = HttpContext.User.Claims.FirstOrDefault()?.Value ?? "";

            var GetPortfolioListForCustomerQuery = new GetPortfolioListForCustomerQuery(userClaim);

            apiServiceResponse = await _mediator.Send(GetPortfolioListForCustomerQuery);

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }
    }
}