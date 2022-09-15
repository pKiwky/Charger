using Charger.Application.Common;
using Charger.Domain.Models.Response.Queries;

namespace Charger.Application.Contracts.Queries {

    public interface IStationQuery {
        Task<PaginatedResult<ResponseGetStation>> GetPaginated(int pageNumber, int pageSize);
    }

}
