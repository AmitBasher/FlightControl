namespace FlightControl.Infrastructure.Repositories {
    public interface IFlightsRepository {
        Task<int> Add(Flight flight);
        Task<Flight?> GetById(int id);
        Task<Flight?> GetByCode(string code);
        Task<int> Modify(Flight flight);
        Task<int> Remove(Flight flight);
        Task<List<Flight>> GetList();
    }

    public class FlightsRepository : IFlightsRepository {
        private readonly FlightControlDB _db;
        public FlightsRepository(FlightControlDB db) {
            _db = db;
        }
        public async Task<Flight?> GetById(int id) =>
            await _db.Flights.FirstOrDefaultAsync(a => a.Id==id);
        public async Task<Flight?> GetByCode(string code) =>
            await _db.Flights.FirstOrDefaultAsync(a => a.FlightCode == code);

        public async Task<List<Flight>> GetList() => 
            await _db.Flights.ToListAsync();
        public async Task<int> Add(Flight flight) {
            await _db.Flights.AddAsync(flight);
            return await _db.SaveChangesAsync();
        }
        public async Task<int> Modify(Flight flight) {
            _db.Flights.Update(flight);
            return await _db.SaveChangesAsync();
        }
        public async Task<int> Remove(Flight flight) {
            _db.Flights.Remove(flight);
            return await _db.SaveChangesAsync();
        }

        
    }
}
