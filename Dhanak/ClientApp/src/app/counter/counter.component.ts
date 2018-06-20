import { ClientService } from './../services/client.service';
import { Component } from '@angular/core';
import { Client } from '../services/Client';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  clients:Client[];
  constructor(public clientService:ClientService)
  {
           this.clientService.getClients().subscribe(client => {this.clients=client,console.log(this.clients)})
  }
  public incrementCounter() {
    this.currentCount++;
  }
}
