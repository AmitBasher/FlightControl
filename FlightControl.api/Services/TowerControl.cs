using FlightControl.Domain.Models;

namespace FlightControl.Api.Services;
public sealed class TowerControlService {

    #region Singleton
    private static TowerControlService _instance = null!;
    private static readonly object _lock = new();
    public TowerControlService(FlightControlService flightControlService) {
        _flightControlService = flightControlService;
        OnUpdateHandler+=FlightChangedEvent!;
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

    
    private readonly FlightControlService _flightControlService;
    private StageControl? _stageControl;
    private event EventHandler<FlightEventArgs> OnUpdateHandler;
    private void InitStageControl() {
        _stageControl=new(FlightChanged, ProcessNextFlight, StagesConfiguration.stagesConfig);
    }
        
    public async Task OnEnter(Flight flight) {
        if (_stageControl==null) 
            { InitStageControl(); }
        var NextStage = flight.IsArriving ? (int)StagesEnum.Landing_A : (int)StagesEnum.TerminalSender;
        NewFlight(this, new FlightEventArgs(flight));
        await Task.Run(() =>
            ProcessNextFlight(new NextStageEventArgs(NextStage, flight))
        );
    }
    //events
    public void ProcessNextFlight(NextStageEventArgs e) {
        if (e.StageId==0) {
            var flight = e.Flight;
            flight.CurrentStage=0;
            _ =_flightControlService.FlightEnd(flight);
            return;
        }
        _=_stageControl!.SendToNext(e.Flight, e.StageId);
    }
    public void NewFlight(object sender, FlightEventArgs e) {
        _flightControlService.NewEntery(e.Flight).Wait();
    }
    public void FlightChangedEvent(object sender, FlightEventArgs e) {
        _flightControlService.NextStage(e.Flight).Wait();
    }
    public void FlightChanged(Flight flight) {
        OnUpdateHandler.Invoke(this,new FlightEventArgs(flight));
    }
    
#pragma warning disable CS8618
    private TowerControlService() {
    }
#pragma warning restore CS8618
}

