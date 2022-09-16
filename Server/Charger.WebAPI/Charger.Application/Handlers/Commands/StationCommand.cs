using Charger.Application.Common.Exceptions;
using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Commands;
using Charger.Domain.Entities;
using Charger.Domain.Models.Request.Commands;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Charger.Application.Handlers.Commands {

    public class StationCommand : IStationCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public StationCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Create(RequestCreateStation requestCreateStation) {
            var entity = requestCreateStation.Adapt<StationEntity>();

            _applicationDbContext.Stations.Add(entity);
            var result = await _applicationDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> Delete(int id) {
            var entity = await _applicationDbContext.Stations.FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null) {
                throw new NotFoundException();
            }

            _applicationDbContext.Stations.Remove(entity);
            return await _applicationDbContext.SaveChangesAsync() != 0;
        }
    }

}
