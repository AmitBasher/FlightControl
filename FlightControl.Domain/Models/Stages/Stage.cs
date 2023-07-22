namespace FlightControl.Domain.Models {
    public class Stage {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int WaitTime_ms { get; set; }
        public int NextDepartureStageId { get; set; }
        public int NextArrivalStageId { get; set; }
        public bool IsTerminal { get; set; }
        public bool IsAvailable { get; set; }
        public Stage() {
            Flights = Channel.CreateUnbounded<Flight>();
        }

        [NotMapped]
        public Action<Flight>? OnFlightUpdate { get; set; }
        [NotMapped]
        public Action<NextStageEventArgs>? OnEndProcess { get; set; }
        [NotMapped]
        protected Channel<Flight> Flights { get; set; }
        protected readonly SemaphoreSlim _stageSemaphore = new(1);

        public async Task AddFlight(Flight flight,SemaphoreSlim? externalSemaphore=null) {
            await Flights.Writer.WriteAsync(flight);
            _=Task.Run(()=>ProcessFlight(externalSemaphore));
        }
        protected virtual async Task ProcessFlight(SemaphoreSlim? externalSemaphore) {
            await _stageSemaphore.WaitAsync();

            Flight flight= await Flights.Reader.ReadAsync();
            flight!.CurrentStage = Id;
            OnFlightUpdate!.Invoke(flight);
            Thread.Sleep(WaitTime_ms);

            var stageId = flight.IsArriving ? NextArrivalStageId : NextDepartureStageId;
            OnEndProcess!.Invoke(new NextStageEventArgs(stageId,flight));

            IsAvailable= true;
            externalSemaphore?.Release();
            _stageSemaphore.Release();
        }
    }
}