import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@microsoft/signalr'
import { StagesService } from './stages.service';
import stage from '../Models/stage.model';
import flight from '../Models/flight.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  route:string = "https://localhost:7081/control";
  
  constructor(public stageService:StagesService,
    public http:HttpClient) { }
  private hubConnection!: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl(this.route)
                            .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .then(this.startHttpRequest)
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addTransferChartDataListener = () => {
    this.hubConnection.on('flightChanged', (flight) => {
      this.stageService.AddFlight(flight);
    });
    this.hubConnection.on('flightFinished', (flight) => {
      this.stageService.FinishFlight(flight);
    });
    this.hubConnection.on('StagesSending', (stages) => {
      this.stageService.DefineProperties(stages);
    });
  }
  public startHttpRequest = () => {
this.http.get('https://localhost:7081/api/Flight')
    .subscribe();
  }
}
