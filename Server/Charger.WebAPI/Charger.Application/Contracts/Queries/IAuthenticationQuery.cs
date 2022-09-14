using Charger.Domain.Models.Request.Commands;

namespace Charger.Application.Contracts.Queries {

    public interface IAuthenticationQuery {
        Task<string> Register(RequestCreateAccount requestCreateAccount);
    }

}
