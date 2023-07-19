using AutoMapper;
using FlightControl.Api.DTO.IMapper;
using FlightControl.Domain.Models;
using System.Runtime.InteropServices;

namespace FlightControl.Api.Services;

public class FlightControlService {
    private readonly IFlightsRepository _flights;
    private readonly HubService _hubService;
    private readonly IFlightsHistoryRepository _flightsHistory;
    private readonly Mapper _mapper;
    private readonly SemaphoreSlim safeBuffer = new(1);
    public FlightControlService(
            IFlightsRepository flightsRepository,
            IFlightsHistoryRepository flightsHistoryRepository,
            HubService hubService) {
        _flights = flightsRepository;
        _flightsHistory = flightsHistoryRepository;
        _hubService = hubService;
        _mapper = MapperConfig.InitializeAutoMapper(); ;
    }
    public async Task NewEntery(Flight flight) {
        safeBuffer.Wait();
        await _flights.Add(flight);
        safeBuffer.Release();
    }
    public async Task FlightEnd(Flight flight) {
        safeBuffer.Wait();
        await _hubService.SendEndFlight(flight);
        await _flights.Modify(flight);
        safeBuffer.Release();
    }
    public async Task NextStage(Flight flight) {
        safeBuffer.Wait();
        await _hubService.SendFlight(flight);
        await _flights.Modify(flight);
        var entity = await _flights.GetByCode(flight.FlightCode!);
        var FlightHistory = _mapper.Map<FlightHistory>(entity);
        FlightHistory.EntryDateTime = DateTime.Now;
        await _flightsHistory.Add(FlightHistory);
        safeBuffer.Release();
    }
    //public async Task PublishChangeToHub(Flight flight) {
    //    await _hubService.SendFlight(flight);
    //}
    //public async Task PublishEndToHub(Flight flight) {
    //    await _hubService.SendEndFlight(flight);
    //}
}
