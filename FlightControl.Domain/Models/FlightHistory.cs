namespace FlightControl.Domain.Models {
    public class FlightHistory {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        //[ForeignKey("Stage")]
        public int StageId { get; set; }
        public DateTime EntryDateTime { get; set; }
    }
}