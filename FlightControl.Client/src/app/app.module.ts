import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LogTableComponent } from './Components/log-table/log-table.component';
import { SignalRService } from './Services/signalr.service';
import { StagesService } from './Services/stages.service';
import {  HttpClientModule } from '@angular/common/http';
import { AirportComponent } from './Components/airport/airport.component';
import { FlightComponent } from './Components/flight/flight.component';

@NgModule({
  declarations: [
    AppComponent,
    LogTableComponent,
    AirportComponent,
    FlightComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [SignalRService,
              StagesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
