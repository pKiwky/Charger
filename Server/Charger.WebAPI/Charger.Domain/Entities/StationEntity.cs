using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Charger.Domain.Entities {

    public class StationEntity : Entity {
        [Column("city")]
        public string City { get; set; }

        [Column("street")]
        public string Street { get; set; }
        
        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }
    }

}
