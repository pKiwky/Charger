using Charger.Domain.Models.Request.Commands;
using Microsoft.AspNetCore.JsonPatch;

namespace Charger.Application.Contracts.Commands {

    public interface ICarCommand {
        Task<int> Create(RequestCreateCar requestCreateCar);
        Task<bool> Patch(int id, int accountId, JsonPatchDocument<RequestUpdateCar> jsonPatchDocument);
    }

}
