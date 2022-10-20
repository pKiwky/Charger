using Charger.Domain.Models.Response.Queries;

namespace Charger.Application.Contracts.Queries {

    public interface ICarQuery {
        Task<IEnumerable<ResponseGetCar>> GetAllByAccountId(int accountId);
    }

}
