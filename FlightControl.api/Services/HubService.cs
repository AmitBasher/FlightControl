namespace FlightControl.Api.Services; 
public class HubService {
    private readonly IHubContext<MyHub> _hubContext;
    public HubService(IHubContext<MyHub> hubContext) { 
        _hubContext = hubContext; 
    }
    public async Task SendFlight(Flight flight) {
        var json = JsonSerializer.Serialize(flight);
        await _hubContext.Clients.All.SendAsync("flightChanged", json);
    }
    public async Task SendEndFlight(Flight flight) {
        var json = JsonSerializer.Serialize(flight);
        await _hubContext.Clients.All.SendAsync("flightFinished", json);
    }
    public async Task SendStages(StageDto[] stages) {
        var json = JsonSerializer.Serialize(stages);
        await _hubContext.Clients.All.SendAsync("StagesSending", json);
    }
}
