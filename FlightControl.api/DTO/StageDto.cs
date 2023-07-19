namespace FlightControl.Api.DTO;
public class StageDto {
    public int Id { get; set; }
    public string? Title { get; set; }
    public int WaitTime_ms { get; set; }
    public int NextDepartureStageId { get; set; }
    public int NextArrivalStageId { get; set; }
    public bool IsTerminal { get; set; }
    public bool IsAvailable { get; set; }
}
