using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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