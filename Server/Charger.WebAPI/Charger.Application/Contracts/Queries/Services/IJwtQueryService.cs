namespace Charger.Application.Contracts.Queries {

    public interface IJwtQueryService {
        string GetJwtToken(int id, string username, string role = null);
    }

}
