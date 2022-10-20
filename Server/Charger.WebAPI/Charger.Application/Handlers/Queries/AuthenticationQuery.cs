using Charger.Application.Common;
using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Models.Request.Queries;
using Charger.Domain.Models.Response.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Cryptography;
using System.Text;

namespace Charger.Application.Handlers.Queries {

    public class AuthenticationQuery : IAuthenticationQuery {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IJwtQueryService _jwtQueryService;

        public AuthenticationQuery(IApplicationDbContext applicationDbContext, IJwtQueryService jwtQueryService) {
            _applicationDbContext = applicationDbContext;
            _jwtQueryService = jwtQueryService;
        }

        public async Task<ResponseLoginModel> LoginIfUserExists(RequestLoginModel requestLoginModel) {
            var accountEntity = await _applicationDbContext.Accounts.FirstOrDefaultAsync(a => a.Username == requestLoginModel.Username);

            if (accountEntity == null || PasswordMatch(requestLoginModel.Password, accountEntity.Password, accountEntity.PasswordKey) == false) {
                return null;
            }

            return new ResponseLoginModel() {
                Username = accountEntity.Username,
                Token = _jwtQueryService.GetJwtToken(accountEntity.Id, accountEntity.Username, accountEntity.Role)
            };
        }

        private bool PasswordMatch(string plainPassword, byte[] password, byte[] passwordKey) {
            using var hmac = new HMACSHA512(passwordKey);
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));

            for (int i = 0; i < password.Length; i++) {
                if (password[i] != passwordHash[i]) {
                    return false;
                }
            }

            return true;
        }
    }

}