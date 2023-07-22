namespace FlightControl.Infrastructure.Repositories;
public class StageRepository : IStageRepository {
    private readonly FlightControlDB _db;
    public StageRepository(FlightControlDB db) {
        _db = db;
    }
    public async Task<Stage?> GetById(int id) =>
        await _db.Stages.FirstOrDefaultAsync(s => s.Id==id);
    public async Task<int> Add(Stage stage) {
        await _db.Stages.AddAsync(stage);
        return await _db.SaveChangesAsync();
    }
    public async Task<int> Modify(Stage stage) {
        _db.Stages.Update(stage);
        return await _db.SaveChangesAsync();
    }
    public async Task<int> Remove(Stage stage) {
        _db.Stages.Remove(stage);
        return await _db.SaveChangesAsync();
    }
}
