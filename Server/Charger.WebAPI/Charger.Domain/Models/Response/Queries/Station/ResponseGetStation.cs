﻿namespace Charger.Domain.Models.Response.Queries {

    public class ResponseGetStation {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
