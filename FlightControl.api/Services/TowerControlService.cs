namespace FlightControl.Api.Services;
public sealed class TowerControlService {

    #region Singleton
    private static TowerControlService _instance = null!;
    private static readonly object _lock = new();
    public TowerControlService(TowerControlDbService flightControlDbService) {
        _flightControlDbService = flightControlDbService;
    }
    //Initialization
    public static TowerControlService Instance {
        get {
            lock (_lock) {
                _instance ??= new TowerControlService();
                return _instance;
            }
        }
    }
    #endregion
    
    private readonly TowerControlDbService _flightControlDbService;
    private StageControl? _stageControl;
    private void InitStageControl() {
        _stageControl=new(FlightChanged, ProcessNextFlight, StagesConfiguration.stagesConfig);
    }
        
    public async Task OnEnter(Flight flight) {
        if (_stageControl==null) 
            { InitStageControl(); }
        var NextStage = flight.IsArriving ? 
            (int)StagesEnum.Landing_A : (int)StagesEnum.TerminalSender;

        NewFlight(this, new FlightEventArgs(flight));
        await Task.Run(() =>
            ProcessNextFlight(new NextStageEventArgs(NextStage, flight))
        );
    }
    public void ProcessNextFlight(NextStageEventArgs e) {
        if (e.StageId==0) {
            var flight = e.Flight;
            flight.CurrentStage=0;
            _ =_flightControlDbService.FlightEnd(flight);
            return;
        }
        _=_stageControl!.SendToNext(e.Flight, e.StageId);
    }
    public void NewFlight(object sender, FlightEventArgs e) {
        _flightControlDbService.NewEntery(e.Flight).Wait();
    }
    public void FlightChanged(Flight flight) {
        _flightControlDbService.NextStage(flight).Wait();
    }
    
#pragma warning disable CS8618
    private TowerControlService() {
    }
#pragma warning restore CS8618
}

