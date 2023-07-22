namespace FlightControl.Api.Services;
public class TowerControlDbService {
    private readonly IFlightsRepository _flights;
    private readonly HubService _hubService;
    private readonly IFlightsHistoryRepository _flightsHistory;
    private readonly Mapper _mapper;
    private readonly SemaphoreSlim safeBuffer = new(1);
    public TowerControlDbService(
            IFlightsRepository flightsRepository,
            IFlightsHistoryRepository flightsHistoryRepository,
            HubService hubService) {
        _flights = flightsRepository;
        _flightsHistory = flightsHistoryRepository;
        _hubService = hubService;
        _mapper = MapperConfig.InitializeAutoMapper(); ;
    }
    public async Task NewEntery(Flight flight) {
        safeBuffer.Wait();
        await _flights.Add(flight);
        safeBuffer.Release();
    }
    public async Task FlightEnd(Flight flight) {
        safeBuffer.Wait();
        await _hubService.SendEndFlight(flight);
        await _flights.Modify(flight);
        safeBuffer.Release();
    }
    public async Task NextStage(Flight flight) {
        safeBuffer.Wait();
        await _hubService.SendFlight(flight);
        await _flights.Modify(flight);
        var entity = await _flights.GetByCode(flight.FlightCode!);
        var FlightHistory = _mapper.Map<FlightHistory>(entity);
        FlightHistory.EntryDateTime = DateTime.Now;
        await _flightsHistory.Add(FlightHistory);
        safeBuffer.Release();
    }
}
