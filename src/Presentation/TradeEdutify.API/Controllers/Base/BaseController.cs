using Microsoft.AspNetCore.Mvc;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public ApiServiceResponse apiServiceResponse;
        public string userClaim;

        public BaseController()
        {
            apiServiceResponse = new ApiServiceResponse();
            userClaim = string.Empty;
        }
    }
}