using System.ComponentModel.DataAnnotations.Schema;

namespace Charger.Domain.Entities {

    public class CarEntity : TrackableEntity {
        [Column("model")]
        public string Model { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        public AccountEntity Account { get; set; }
    }

}
