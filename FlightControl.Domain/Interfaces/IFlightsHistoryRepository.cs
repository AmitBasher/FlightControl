namespace FlightControl.Domain.Interfaces;

public interface IFlightsHistoryRepository {
    Task<int> Add(FlightHistory flightHistory);
    Task<FlightHistory?> GetById(int id);
    Task<List<FlightHistory>> GetList();
    Task<int> Modify(FlightHistory flightHistory);
    Task<int> Remove(FlightHistory flightHistory);
}
