using System.ComponentModel.DataAnnotations.Schema;

namespace Charger.Domain.Entities {

    public class AccountEntity : TrackableEntity {
        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role")]
        public string Role { get; set; }
    }

}