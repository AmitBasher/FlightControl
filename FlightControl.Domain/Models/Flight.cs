namespace FlightControl.Domain.Models {
    public class Flight {
        [Key]
        public int Id { get; private set; }
        [ForeignKey("Stage")]
        public int CurrentStage { get; set; }
        public string? FlightCode { get; set; }
        public string? Destination { get; set; }
        public string? Airline { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsArriving { get; set; }
    }
}