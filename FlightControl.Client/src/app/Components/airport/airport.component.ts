import { Component, OnInit } from '@angular/core';
import stage from '../../Models/stage.model';
import { StagesService } from '../../Services/stages.service';

@Component({
  selector: 'app-airport',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.css']
})
export class AirportComponent implements OnInit {
  constructor(public stageService: StagesService){}
  ngOnInit(): void {
    this.Stages = this.stageService.Stages;
  }
  Stages:stage[] = [];

  straightImg="assets/straight.png";
  landingImg="assets/landing.png";
  takeOffImg="assets/take-off.png";
  
}
