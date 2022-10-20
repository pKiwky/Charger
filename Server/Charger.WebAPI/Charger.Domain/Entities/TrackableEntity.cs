using System.ComponentModel.DataAnnotations.Schema;

namespace Charger.Domain.Entities {

    public class TrackableEntity : Entity {
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }

}