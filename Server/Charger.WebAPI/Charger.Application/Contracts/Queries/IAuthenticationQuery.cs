using Charger.Domain.Models.Request.Commands;
using Charger.Domain.Models.Request.Queries;

namespace Charger.Application.Contracts.Queries {

    public interface IAuthenticationQuery {
        Task<string> LoginIfUserExists(RequestLoginModel requestLoginModel);
    }

}
