using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeEdutify.Application.Dtos;
using TradeEdutify.Application.Features.Queries.ShareQueries;
using TradeEdutify.Application.Parameters;
using TradeEdutify.Application.Parameters.RequestParameters;

namespace TradeEdutify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ShareController : ControllerBase
    {

        private readonly IMediator mediator;
        private ApiServiceResponse apiServiceResponse;
        private string userClaim;

        public ShareController(IMediator mediator)
        {
            this.mediator = mediator;
            apiServiceResponse = new ApiServiceResponse();
        }

        [HttpPost("UpdateShare")]
        public async Task<IActionResult> UpdateShare(List<ShareDto> ShareList)
        {
            var UpdateShareQuery = new UpdateShareQuery(ShareList);

            apiServiceResponse = await mediator.Send(UpdateShareQuery);

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }

        [HttpGet("GetShareList")]
        public async Task<IActionResult> GetShareList()
        {
            var GetShareListQuery = new GetShareListQuery();

            apiServiceResponse = await mediator.Send(GetShareListQuery);

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }

        [HttpPost("BuyShare")]
        public async Task<IActionResult> BuyShare(ShareTransactionRequestModel shareTransactionRequestModel)
        {
            userClaim = HttpContext.User.Claims.FirstOrDefault().Value;

            var BuyShareQuery = new BuyShareQuery(shareTransactionRequestModel, userClaim);

            apiServiceResponse = await mediator.Send(BuyShareQuery);

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }

        [HttpPost("SellShare")]
        public async Task<IActionResult> SellShare(ShareTransactionRequestModel shareTransactionRequestModel)
        {
            userClaim = HttpContext.User.Claims.FirstOrDefault().Value;

            var SellShareQuery = new SellShareQuery(shareTransactionRequestModel, userClaim);

            apiServiceResponse = await mediator.Send(SellShareQuery);

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }


    }
}
