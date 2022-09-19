using Charger.Application.Contracts.Commands;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Enums;
using Charger.Domain.Models.Request.Commands;
using Charger.Domain.Models.Request.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Charger.WebAPI.Controllers {

    public class AuthenticationController : ApiController {
        private readonly IAuthenticationCommand _authenticationCommand;
        private readonly IAuthenticationQuery _authenticationQuery;

        public AuthenticationController(IAuthenticationCommand authenticationCommand, IAuthenticationQuery authenticationQuery) {
            _authenticationCommand = authenticationCommand;
            _authenticationQuery = authenticationQuery;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] RequestLoginModel requestLoginModel) {
            var user = await _authenticationQuery.LoginIfUserExists(requestLoginModel);

            if (user == null) {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RequestRegisterModel requestRegisterModel) {
            var result = await _authenticationCommand.Register(requestRegisterModel);

            if (result.RegisterResponse != ERegisterResponse.Success) {
                return BadRequest(result.Data);
            }

            return Ok(new { token = result.Data });
        }
    }

}