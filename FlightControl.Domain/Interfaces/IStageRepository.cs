namespace FlightControl.Domain.Interfaces;

public interface IStageRepository {
    Task<int> Add(Stage stage);
    Task<Stage?> GetById(int id);
    Task<int> Modify(Stage stage);
    Task<int> Remove(Stage stage);
}
