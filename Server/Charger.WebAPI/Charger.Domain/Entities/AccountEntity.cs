using System.ComponentModel.DataAnnotations.Schema;

namespace Charger.Domain.Entities {

    public class AccountEntity : TrackableEntity {
        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public byte[] Password { get; set; }

        [Column("password_key")]
        public byte[] PasswordKey { get; set; }

        [Column("role")]
        public string Role { get; set; }
    }

}