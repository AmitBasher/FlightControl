using FlightControl.Simulator.Models;
using System.Net.Http.Json;

namespace FlightControl.Simulator {
    internal class Program {
        static readonly HttpClient client = new() 
        { BaseAddress= new Uri("https://localhost:7081") };
        static void Main(string[] args) {
            var timer = new System.Timers.Timer(2500);
            timer.Elapsed+=(s, e) => _=CreateFlight();
            timer.Elapsed+=(s, e) => ChangeTimerInterval(s!);
            timer.Start();
            Console.WriteLine("Simulator Started");
            Console.ReadKey();
        }
        private static async Task CreateFlight() {
            var flight = new FlightDto();
            Console.WriteLine($"Flight sent:");
            Console.WriteLine($"{flight}");
            try {
                var response = await client.PostAsJsonAsync("api/Flight", flight);
                Console.WriteLine("Response:");
                Console.WriteLine(response);
            }
            catch (Exception ex) 
            { Console.WriteLine(ex.Message); }
        }
        private static void ChangeTimerInterval(object source) {
            var timer = source as System.Timers.Timer;
            Random rnd = new();
            timer!.Interval = rnd.Next(2000, 4000);
        }

    }
}