using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightControl.Api.Models {
    public class FlightDto {
        public string? FlightCode { get; set; }
        public string? Destination { get; set; }
        public string? Airline { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsArriving { get; set; }
    }
}
