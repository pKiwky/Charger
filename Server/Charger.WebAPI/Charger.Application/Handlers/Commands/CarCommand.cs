using Charger.Application.Common.Exceptions;
using Charger.Application.Common.Interfaces;
using Charger.Application.Contracts.Commands;
using Charger.Domain.Entities;
using Charger.Domain.Models.Request.Commands;
using Charger.Domain.Models.Response.Queries;
using Mapster;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;

namespace Charger.Application.Handlers.Commands {

    public class CarCommand : ICarCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public CarCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Create(RequestCreateCar requestCreateCar) {
            var entity = requestCreateCar.Adapt<CarEntity>();
            entity.CreatedDate = DateTime.Now;

            _applicationDbContext.Cars.Add(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> Patch(int id, int accountId, JsonPatchDocument<RequestUpdateCar> jsonPatchDocument) {
            var entity = _applicationDbContext.Cars
                .FirstOrDefault(c => c.Id == id && c.Deleted == false);

            if (entity == null || entity.AccountId != accountId) {
                throw new NotFoundException(nameof(CarEntity), id);
            }

            var entityMapped = entity.Adapt<RequestUpdateCar>();
            jsonPatchDocument.ApplyTo(entityMapped);

            entityMapped.Adapt(entity);
            return await _applicationDbContext.SaveChangesAsync() != 0;
        }
    }

}
