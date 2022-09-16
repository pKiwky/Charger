using Charger.Domain.Models.Request.Commands;

namespace Charger.Application.Contracts.Commands {

    public interface IStationCommand {
        Task<int> Create(RequestCreateStation requestCreateStation);
        Task<bool> Delete(int id);
    }

}
