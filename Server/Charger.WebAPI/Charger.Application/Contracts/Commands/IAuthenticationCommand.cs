using Charger.Domain.Models.Request.Commands;

namespace Charger.Application.Contracts.Commands {

    public interface IAuthenticationCommand {
        Task<string> Register(RequestRegisterModel requestCreateAccount);
    }

}
