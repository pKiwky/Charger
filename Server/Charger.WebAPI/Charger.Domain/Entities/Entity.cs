using System.ComponentModel.DataAnnotations.Schema;

namespace Charger.Domain.Entities {

    public class Entity {
        [Column("id")]
        public int Id { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; }

        // DeletedBy
        // DeletedDate
    }

}
