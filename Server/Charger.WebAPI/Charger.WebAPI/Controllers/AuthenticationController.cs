using Charger.Application.Contracts.Commands;
using Charger.Application.Contracts.Queries;
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
            string token = await _authenticationQuery.LoginIfUserExists(requestLoginModel);

            if (string.IsNullOrEmpty(token)) {
                return NotFound();
            }

            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RequestRegisterModel requestRegisterModel) {
            string token = await _authenticationCommand.Register(requestRegisterModel);

            if (string.IsNullOrEmpty(token)) {
                return BadRequest();
            }

            return Ok(token);
        }
    }

}