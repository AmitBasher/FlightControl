//namespace FlightControl.Domain.ModelService;
//public class StageModelService {
//    public StageModelService(Stage stage) {
//        Stage = stage;
//    }
//    public Stage Stage { get; set; }
//    public Action<Flight>? OnFlightUpdate { get; set; }
//    public Action<NextStageEventArgs>? OnEndProcess { get; set; }
//    protected Channel<Flight> Flights { get; set; } = Channel.CreateUnbounded<Flight>();

//    protected readonly SemaphoreSlim _semaphoreProcess = new(1);
//    public async Task AddFlight(Flight flight, SemaphoreSlim semaphore = null) {
//        await Flights.Writer.WriteAsync(flight);
//        _=Task.Run(() => ProcessFlight(semaphore));
//    }
//    protected virtual async Task ProcessFlight(SemaphoreSlim semaphore) {
//        await _semaphoreProcess.WaitAsync();

//        Flight flight = await Flights.Reader.ReadAsync();
//        flight!.CurrentStage = Stage.Id;
//        OnFlightUpdate!.Invoke(flight);
//        Thread.Sleep(Stage.WaitTime_ms);

//        var stageId = flight.IsArriving ? Stage.NextArrivalStageId : Stage.NextDepartureStageId;
//        OnEndProcess!.Invoke(new NextStageEventArgs(stageId, flight));

//        Stage.IsAvailable= true;
//        semaphore?.Release();
//        _semaphoreProcess.Release();
//    }
//}
