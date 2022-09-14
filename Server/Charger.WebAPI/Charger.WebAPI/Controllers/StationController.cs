using Charger.Application.Contracts.Commands;
using Charger.Domain.Models.Request.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Charger.WebAPI.Controllers {

    public class StationController : ApiController {
        private readonly IStationCommand _stationCommand;

        public StationController(IStationCommand stationCommand) {
            _stationCommand = stationCommand;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] RequestCreateStation requestCreateStation) {
            int id = await _stationCommand.Create(requestCreateStation);
            return id;
        }
    }

}
