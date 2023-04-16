using hw2.Core.Services;
using hw2.Core.Token;
using Microsoft.AspNetCore.Mvc;

namespace hw2.API.Token
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController: ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;

        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }
        [HttpPost("Login")]
        public TokenResponse Login([FromBody] TokenRequest request)
        {
            return tokenManagementService.GenerateToken(request);
        }
    }
}
