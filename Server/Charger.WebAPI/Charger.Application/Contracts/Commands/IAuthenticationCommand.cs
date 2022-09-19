using Charger.Domain.Models.Request.Commands;
using Charger.Domain.Models.Response.Commands;

namespace Charger.Application.Contracts.Commands {

    public interface IAuthenticationCommand {
        Task<ResponseRegisterModel> Register(RequestRegisterModel requestCreateAccount);
    }

}
