import { AngularFireDatabase } from 'angularfire2/database';

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from './Client';



@Injectable(
  
)
export class ClientService {
  clients:Observable<any[]>;;
  client:Observable<any>;

  constructor(public af:AngularFireDatabase) {
    this.clients=this.af.list('clients').valueChanges();

   }
   getClients()
   {
     return this.clients;
   }
}
