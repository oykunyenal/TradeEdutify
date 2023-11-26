using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeEdutify.Application.Interfaces.Services;
using TradeEdutify.Application.Parameters;
using TradeEdutify.Application.Services;

namespace TradeEdutify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ITokenService tokenService;
        public UserController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost("GetToken")]
        public IActionResult GetAuthToken(string Username)
        {
            var TokenResponse = tokenService.GenerateToken(Username);

            ApiServiceResponse apiServiceResponse = new ApiServiceResponse
            {
                Message = "",
                Object = TokenResponse,
                Result = true
            };

            if (!apiServiceResponse.Result)
            {
                return BadRequest(apiServiceResponse);
            }

            return Ok(apiServiceResponse);
        }
    }
}
