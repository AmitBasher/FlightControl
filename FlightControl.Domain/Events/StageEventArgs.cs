namespace FlightControl.Domain.Events;
public class NextStageEventArgs : EventArgs {
    public int StageId { get; }
    public Flight Flight { get; }
    public NextStageEventArgs(int stageId, Flight flight) {
        StageId = stageId;
        Flight=flight;
    }
}
