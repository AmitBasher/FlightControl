namespace FlightControl.Domain.Models; 
public class StageControl {
    public Stage[] Stages { get; set; }
    public Stage[] Terminals { get; set; }

    public StageControl(Action<Flight> update, Action<NextStageEventArgs> endProcess, Stage[] stages)
    {
        List<Stage> Terminals = new();
        List<Stage> Stages = new();
        foreach (var stage in stages) {
            stage.OnFlightUpdate = update;
            stage.OnEndProcess = endProcess;
            if(stage.IsTerminal) Terminals.Add(stage);
            else Stages.Add(stage);
        }
        this.Stages = Stages.ToArray();
        this.Terminals = Terminals.ToArray();
        TerminalSemaphore = new(this.Terminals.Length);
    }
    private IEnumerable<Stage?> GetStages() {
        foreach (var stage in Stages) {
            yield return stage;
        }
        foreach (var stage in Terminals) {  
            yield return stage; 
        }
    }
    private Stage? GetStageById(int id) {
        foreach (var stage in GetStages()) {
            if(stage!.Id== id) return stage;
        }
        return null;
    }
    public async Task SendToNext(Flight flight,int stageId) {
        if (stageId==51) {
            await TerminalSender.Writer.WriteAsync(flight);
            await TerminalRunner();
        }
        else {
            await GetStageById(stageId)!.AddFlight(flight);
        }
    }

    #region Terminal Runner
    public Channel<Flight> TerminalSender = Channel.CreateUnbounded<Flight>();
    private SemaphoreSlim TerminalSemaphore { get; set; }
    public async Task TerminalRunner() {
        await Task.Run(async() => {
            await TerminalSemaphore.WaitAsync();
            foreach (var terminal in Terminals) {
                if (terminal.IsAvailable) {
                    await terminal.AddFlight(await TerminalSender.Reader.ReadAsync(),TerminalSemaphore);
                    terminal.IsAvailable=false;
                    break;
                }
            }
        });
    }
    #endregion

}