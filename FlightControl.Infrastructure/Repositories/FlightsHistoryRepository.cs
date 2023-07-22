namespace FlightControl.Infrastructure.Repositories; 
public class FlightsHistoryRepository : IFlightsHistoryRepository {
private readonly FlightControlDB _db;
public FlightsHistoryRepository(FlightControlDB db) {
    _db = db;
}
public async Task<int> Add(FlightHistory flightHistory) {
    await _db.FlightsHistory.AddAsync(flightHistory);
    return await _db.SaveChangesAsync();
}
public async Task<int> Remove(FlightHistory flightHistory) {
    _db.FlightsHistory.Remove(flightHistory);
    return await _db.SaveChangesAsync();
}
public async Task<int> Modify(FlightHistory flightHistory) {
    _db.FlightsHistory.Update(flightHistory);
    return await _db.SaveChangesAsync();
}
public async Task<FlightHistory?> GetById(int id) =>
    await _db.FlightsHistory.FirstOrDefaultAsync(a => a.Id==id);
public async Task<List<FlightHistory>> GetList() =>
    await _db.FlightsHistory.ToListAsync();

}
