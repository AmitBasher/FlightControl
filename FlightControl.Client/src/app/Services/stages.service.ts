import { Injectable } from '@angular/core';
import stage from '../Models/stage.model';
import flight from '../Models/flight.model';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StagesService {
  constructor() {}
  public Waiting:flight[]=[];
  public Stages:stage[]=[];
  public Finished:flight[]=[];

  public Despatching:stage[]=[];
  public Common:stage[]=[];
  public Terminal:stage[]=[];
  public Landing:stage[]=[];

  public DefineProperties(stages:any){
    const Mapped:stage[] =[];
    const array = JSON.parse(stages) as any[];
    array.forEach(element => {
      Mapped.push(
        new stage(
          element['Id'],
          element['Title'],
          element['NextDepartureStageId'],
          element['NextArrivalStageId'],
          element['IsTerminal']
          ));
    });
    Mapped.forEach(s => {
      this.Stages.push(s);
    });
    this.Buildroute(stages);
  }

  public Buildroute=(stages:stage[])=>{
    stages.forEach(s => {
      if(s.isTerminal){
        this.Terminal.push(s);
      }
      else if(s.NextArrivalStageId!=0&&s.NextDepartureStageId!=0){
        this.Common.push(s);
      }
      else if(s.NextArrivalStageId!=0){
        this.Landing.push(s);
      }
      else if(s.NextDepartureStageId!=0){
        this.Despatching.push(s);
      }
    });
    this.Despatching= this.Despatching.sort(s=>s.id);
    this.Common= this.Common.sort(s=>s.id);
    this.Terminal= this.Terminal.sort(s=>s.id);
    this.Landing= this.Landing.sort(s=>s.id);
  }
  
  public AddFlight(Flight:any){
    let fl = JSON.parse(Flight) as flight;
    this.DeleteOld(fl);
    let flag = true;
    this.Stages.forEach(stage => {
      if(stage.id==fl.CurrentStage)
      {stage.Flights.push(fl); flag=false; return;}
    });
    if(flag){
      this.Waiting.push(fl);
    }
  }
  public FinishFlight(Flight:any){
    let fl = JSON.parse(Flight) as flight;
    this.DeleteOld(fl);
    this.Finished.push(fl);
  }
  private DeleteOld(Flight:flight){
    this.Stages.forEach(stage => {
      stage.Flights = stage.Flights.filter(fl=>fl.Id!=Flight.Id);
    });
  }
}
