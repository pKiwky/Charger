using Charger.Application.Contracts.Commands;
using Charger.Application.Contracts.Queries;
using Charger.Domain.Models.Request.Commands;
using Charger.Domain.Models.Response.Queries;
using Charger.WebAPI.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Charger.WebAPI.Controllers {

    public class CarController : ApiController {
        private readonly ICarCommand _carCommand;
        private readonly ICarQuery _carQuery;

        public CarController(ICarCommand carCommand, ICarQuery carQuery) {
            _carCommand = carCommand;
            _carQuery = carQuery;
        }

        [HttpPost]
        [Authorize()]
        public async Task<int> Create([FromBody] RequestCreateCar requestCreateCar) {
            requestCreateCar.AccountId = HttpContext.GetUserId();

            int id = await _carCommand.Create(requestCreateCar);
            return id;
        }

        [HttpGet]
        [Authorize()]
        public async Task<IEnumerable<ResponseGetCar>> GetAllByAccountID() {
            int accountId = HttpContext.GetUserId();

            return await _carQuery.GetAllByAccountId(accountId);
        }

        [HttpPatch]
        [Authorize()]
        public async Task<bool> Patch(int id, JsonPatchDocument<RequestUpdateCar> jsonPatchDocument) {
            int accountId = HttpContext.GetUserId();

            return await _carCommand.Patch(id, accountId, jsonPatchDocument);
        }
    }
}
