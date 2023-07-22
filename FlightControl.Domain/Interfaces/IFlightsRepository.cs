namespace FlightControl.Domain.Interfaces;
public interface IFlightsRepository {
    Task<int> Add(Flight flight);
    Task<Flight?> GetById(int id);
    Task<Flight?> GetByCode(string code);
    Task<int> Modify(Flight flight);
    Task<int> Remove(Flight flight);
    Task<List<Flight>> GetList();
}