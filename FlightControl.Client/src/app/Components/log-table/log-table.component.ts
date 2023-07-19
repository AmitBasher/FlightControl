import { Component, OnInit } from '@angular/core';
import { StagesService } from '../../Services/stages.service';
import { SignalRService } from '../../Services/signalr.service';
import stage from '../../Models/stage.model';
import flight from '../../Models/flight.model';

import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-log-table',
  templateUrl: './log-table.component.html',
  styleUrls: ['./log-table.component.css']
})
export class LogTableComponent implements OnInit {
  constructor(
    public signalrService:SignalRService, 
    public stageService:StagesService ,
    public http:HttpClient){}
  ngOnInit(): void {
    this.signalrService.startConnection();
    this.signalrService.addTransferChartDataListener(); 
    this.Stages = this.stageService.Stages;
    this.Waiting = this.stageService.Waiting;
    this.Finished = this.stageService.Finished;
  }
  Waiting:flight[]=[];
  Stages:stage[]=[];
  Finished:flight[]=[];
}
