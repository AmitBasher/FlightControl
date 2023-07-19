namespace FlightControl.Domain.Models {
    public enum StagesEnum {
        Landing_A = 1,
        Landing_B = 2,
        Landing_C = 3,
        Runaway = 4,
        ToTerminal_Landing = 5,
        TerminalSender = 51,
        Terminal_A = 6,
        Terminal_B = 7,
        DispatchingReady = 8,
        Dispatched = 9
    }
}