﻿using Microsoft.AspNetCore.Mvc;

namespace FlightControl.Api.Controllers; 
[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase {
    private readonly TowerControlService _towerControlService;
    private readonly HubService _myHub;
    private readonly Mapper _mapper;

    public FlightController(
        TowerControlService towerControlService,
        HubService myHub
        ) {
        _towerControlService = towerControlService;
        _mapper = MapperConfig.InitializeAutoMapper();
        _myHub = myHub;
    }
    [HttpPost]
    public async Task<ActionResult<Flight>> AddFlight(FlightDto flightDto) {
        var flight = _mapper.Map<Flight>(flightDto);
        await Task.Run(async ()=> { await _towerControlService.OnEnter(flight); });
        return Ok();
    }
    [HttpGet]
    public async Task<ActionResult> SendStages() {
        var array2 = _mapper.Map<Stage[],StageDto[]>(StagesConfiguration.stagesConfig);
        await _myHub.SendStages(array2);
        return Ok();
    }
}
