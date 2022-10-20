using Charger.Application.Common;
using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Commands;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Entities;
using Charger.Domain.Enums;
using Charger.Domain.Models.Request.Commands;
using Charger.Domain.Models.Response.Commands;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Charger.Application.Handlers.Commands {

    public class AuthenticationCommand : IAuthenticationCommand {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IJwtQueryService _jwtQueryService;

        public AuthenticationCommand(IApplicationDbContext applicationDbContext, IJwtQueryService jwtQueryService) {
            _applicationDbContext = applicationDbContext;
            _jwtQueryService = jwtQueryService;
        }

        public async Task<ResponseRegisterModel> Register(RequestRegisterModel requestCreateAccount) {
            var accountAlreadyExists = await _applicationDbContext.Accounts.FirstOrDefaultAsync(a => a.Username == requestCreateAccount.Username);

            if (accountAlreadyExists != null) {
                return new ResponseRegisterModel() {
                    RegisterResponse = ERegisterResponse.UsernameAlreadyUsed,
                    Data = "Username is already used."
                };
            }

            using var hmac = new HMACSHA512();

            var accountEntity = new AccountEntity() {
                Username = requestCreateAccount.Username,
                PasswordKey = hmac.Key,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(requestCreateAccount.Password)),
                Role = "",
                CreatedDate = DateTime.Now
            };

            _applicationDbContext.Accounts.Add(accountEntity);
            bool success = await _applicationDbContext.SaveChangesAsync() != 0;

            if (success) {
                return new ResponseRegisterModel() {
                    RegisterResponse = ERegisterResponse.Success,
                    Data = _jwtQueryService.GetJwtToken(accountEntity.Id, accountEntity.Username)
                };
            }

            return new ResponseRegisterModel() {
                RegisterResponse = ERegisterResponse.Unknown,
                Data = "Unknown error"
            };
        }
    }

}