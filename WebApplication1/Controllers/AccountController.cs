using Api.Authentication;
using CommonModels.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AdminAccountService _adminAccountService;

        public AccountController(AdminAccountService adminAccountService)
        {
            _adminAccountService = adminAccountService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<AdminSession> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_adminAccountService);
            var adminSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserName, loginRequest.Password);
            if (adminSession is null)
                return Unauthorized();
            else
                return adminSession;
        }
    }
}
