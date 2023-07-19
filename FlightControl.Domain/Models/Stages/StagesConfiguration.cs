namespace FlightControl.Domain.Models {
    public static class StagesConfiguration {
        public static readonly Stage[] stagesConfig = {
            new Stage() { Id = 1, Title = "Landing Stage A" ,WaitTime_ms=3000 ,NextArrivalStageId=2},
            new Stage() { Id = 2, Title = "Landing Stage B", WaitTime_ms=3000 ,NextArrivalStageId=3},
            new Stage() { Id = 3, Title = "Landing Stage C", WaitTime_ms=3000 ,NextArrivalStageId=4},
            new Stage() { Id = 4, Title = "Runaway", WaitTime_ms=3000 ,NextArrivalStageId=5, NextDepartureStageId=9},
            new Stage() { Id = 5, Title = "Ready For Terminal", WaitTime_ms=3000, NextArrivalStageId=51},
            new Stage() { Id = 6, Title = "Terminal A", WaitTime_ms=3000, IsTerminal=true,IsAvailable=true, NextArrivalStageId=0, NextDepartureStageId=8},
            new Stage() { Id = 7, Title = "Terminal B", WaitTime_ms=3000, IsTerminal=true,IsAvailable=true, NextArrivalStageId=0, NextDepartureStageId=8 },
            new Stage() { Id = 8, Title = "Dispatching Ready", WaitTime_ms=3000, NextDepartureStageId=4 },
            new Stage() { Id = 9, Title = "Dispatched", WaitTime_ms=3000, NextDepartureStageId=0}
        };
    }
}