namespace FlightControl.Domain.Events
{
    public class FlightEventArgs : EventArgs
    {
        public Flight Flight { get; }

        public FlightEventArgs(Flight flight)
        {
            Flight = flight;
        }
    }

}
