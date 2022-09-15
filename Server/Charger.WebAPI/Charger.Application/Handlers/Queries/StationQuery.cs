using Charger.Application.Common;
using Charger.Application.Common.Extensions;
using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Entities;
using Charger.Domain.Models.Response.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Charger.Application.Handlers.Queries {

    public class StationQuery : IStationQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public StationQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<PaginatedResult<ResponseGetStation>> GetPaginated(int pageNumber, int pageSize) {
            return await _applicationDbContext.Stations.GetPaginated<StationEntity, ResponseGetStation>(pageNumber, pageSize);
        }
    }
};
