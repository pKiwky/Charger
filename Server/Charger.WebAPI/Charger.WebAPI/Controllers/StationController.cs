using Charger.Application.Common;
using Charger.Application.Contracts.Commands;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Models.Request.Commands;
using Charger.Domain.Models.Response.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Charger.WebAPI.Controllers {

    public class StationController : ApiController {
        private readonly IStationCommand _stationCommand;
        private readonly IStationQuery _stationQuery;

        public StationController(IStationCommand stationCommand, IStationQuery stationQuery) {
            _stationCommand = stationCommand;
            _stationQuery = stationQuery;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<int> Create([FromBody] RequestCreateStation requestCreateStation) {
            int id = await _stationCommand.Create(requestCreateStation);
            return id;
        }

        [HttpGet]
        [Route("GetPaginated/{pageNumber}/{pageSize}")]
        public async Task<PaginatedResult<ResponseGetStation>> GetPaginated(int pageNumber, int pageSize) {
            return await _stationQuery.GetPaginated(pageNumber, pageSize);
        }

        [HttpDelete]
        [Route("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<bool> Delete(int id) {
            return await _stationCommand.Delete(id);
        }
    }

}
