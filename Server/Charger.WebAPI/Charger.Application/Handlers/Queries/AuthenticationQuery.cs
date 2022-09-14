using Charger.Application.Common;
using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Models.Request.Queries;
using Microsoft.EntityFrameworkCore;

namespace Charger.Application.Handlers.Queries {

    public class AuthenticationQuery : IAuthenticationQuery {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IJwtQueryService _jwtQueryService;

        public AuthenticationQuery(IApplicationDbContext applicationDbContext, IJwtQueryService jwtQueryService) {
            _applicationDbContext = applicationDbContext;
            _jwtQueryService = jwtQueryService;
        }

        public async Task<string> LoginIfUserExists(RequestLoginModel requestLoginModel) {
            var accountEntity = await _applicationDbContext.Accounts.FirstOrDefaultAsync(a =>
                a.Username == requestLoginModel.Username && a.Password == Utils.CreateSHA512(requestLoginModel.Password)
            );

            if (accountEntity == null) {
                return "";
            }

            return _jwtQueryService.GetJwtToken(accountEntity.Id, accountEntity.Username, accountEntity.Role);
        }
    }

}