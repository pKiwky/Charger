using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Commands;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Entities;
using Charger.Domain.Models.Request.Commands;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Charger.Application.Handlers.Commands {

    public class AuthenticationCommand : IAuthenticationCommand {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IJwtQueryService _jwtQueryService;

        public AuthenticationCommand(IApplicationDbContext applicationDbContext, IJwtQueryService jwtQueryService) {
            _applicationDbContext = applicationDbContext;
            _jwtQueryService = jwtQueryService;
        }

        public async Task<string> Register(RequestRegisterModel requestCreateAccount) {
            var accountAlreadyExists = await _applicationDbContext.Accounts.FirstOrDefaultAsync(a => a.Username == requestCreateAccount.Username);

            if (accountAlreadyExists != null) {
                return "Usernamed is already used.";
            }

            var accountEntity = requestCreateAccount.Adapt<AccountEntity>();
            _applicationDbContext.Accounts.Add(accountEntity);
            bool success = await _applicationDbContext.SaveChangesAsync() != 0;

            if (success) {
                return _jwtQueryService.GetJwtToken(accountEntity.Id, accountEntity.Username);
            }

            return string.Empty;
        }
    }

}
