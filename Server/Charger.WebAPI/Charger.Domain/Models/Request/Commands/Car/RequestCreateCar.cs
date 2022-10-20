namespace Charger.Domain.Models.Request.Commands {

    public class RequestCreateCar {
        public int AccountId { get; set; }
        public string Model { get; set; }
    }

}
