using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Models.Response.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Charger.Application.Handlers.Queries {

    public class CarQuery : ICarQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public CarQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ResponseGetCar>> GetAllByAccountId(int accountId) {
            return await _applicationDbContext.Cars
                .AsNoTracking()
                .Where(c => c.AccountId == accountId && c.Deleted == false)
                .ProjectToType<ResponseGetCar>()
                .ToListAsync();
        }
    }

}
