import { Component, Input } from '@angular/core';
import flight from 'src/app/Models/flight.model';

@Component({
  selector: 'flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent {
  @Input() path:string="";
  @Input() Flight:string="";
  @Input() Airline:string="";
}
