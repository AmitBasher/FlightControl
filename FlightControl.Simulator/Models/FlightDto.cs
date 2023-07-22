namespace FlightControl.Simulator.Models; 
public class FlightDto {
    public string FlightCode { get; set; }
    public string Destination { get; set; }
    public string Airline { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsArriving { get; set; }
    public FlightDto() {
        Random rand = new();
        FlightCode=Guid.NewGuid().ToString()[..5].ToUpper();
        IsArriving = rand.Next(2)==0;
        Destination = _destinations[
            IsArriving ? 0 : rand.Next(1,_destinations.Length)
        ];
        CreatedAt = DateTime.Now;
        Airline= _airlines[rand.Next(_airlines.Length)];
    }
    public override string ToString() {
        return $"{FlightCode} - To {Destination}, plane - {Airline},is arriving - {IsArriving}";
    }
    private readonly string[] _destinations =
        { "ISR", "ISL", "HKG", "DEU", "CHN", "COL",
        "CAN", "BRA", "BGR", "USA", "BEL", "NZL", "RUS"};

    private static readonly string[] _airlines =
        { "Delta-Air", "American-Airlines", "Lufthansa",
        "Air-France", "Southwest", "Emirates",
        "British-Airways", "El-Al", "EasyJet", "AirAsia" };
}
