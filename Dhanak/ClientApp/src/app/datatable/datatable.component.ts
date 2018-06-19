import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from './../services/data.service';
import { Http } from '@angular/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.css']
})
export class DatatableComponent implements OnInit {

  events:any[];
  constructor(public dataService:DataService,public route:Router) {
    this.dataService.getEvents().subscribe(e => this.events=e);
    
    
   }

  ngOnInit() {
      
  }
  onClick(id)
  {
    this.route.navigate(["/edit/"+id]);
    
  }

}
