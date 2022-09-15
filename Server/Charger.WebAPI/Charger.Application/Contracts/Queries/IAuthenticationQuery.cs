using Charger.Domain.Models.Request.Queries;
using Charger.Domain.Models.Response.Queries;

namespace Charger.Application.Contracts.Queries {

    public interface IAuthenticationQuery {
        Task<ResponseLoginModel> LoginIfUserExists(RequestLoginModel requestLoginModel);
    }

}
