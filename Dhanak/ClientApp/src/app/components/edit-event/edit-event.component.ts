import { category, events } from './../events';
import { DataService } from './../../services/data.service';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { event } from '../new-event/event';

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.css']
})
export class EditEventComponent implements OnInit,AfterViewInit {

  Id:number;
  categoryid:number;
  validity:boolean=true;
  category:any[];
  cid:number;

  cName:string;
  events:events = { eventName:'',description:'',categoryId:{id:0,name:''},coOrdinator:{name:'',phone:''},organiser:{name:'',phone:'',email:''}}
 
  event:event = { eventName:'',description:'',categoryId:0,coOrdinator:{name:'',phone:''},organiser:{name:'',phone:'',email:''}}
 
 
  constructor(private route: ActivatedRoute,private dataservice:DataService) {
    this.route.params.subscribe( params => this.Id=params.id );
    this.dataservice.getEvent(this.Id).subscribe(res => {this.event=res,this.categoryid=res.categoryId});
    //this.categoryid=this.events.categoryId.toString();
    this.dataservice.getEvent(this.Id).subscribe(res =>{this.events.eventName=res.eventName,this.dataservice.getCategories(res.categoryId).subscribe(a=>{this.events.categoryId=a}),this.events.description=this.event.description,this.events.coOrdinator=res.coOrdinator,this.events.organiser=res.organiser});
    this.dataservice.getCategory().subscribe(res => this.category=res)
    
    
   }
   
   

     
 


   onSubmit({value,valid})
   {
        if(valid)
        {
           
          console.log("pass")     
          console.log(this.events);
        }
        else{
          this.validity=false;
          console.log(value)
          console.log("fail");
        }
   }


  ngOnInit() {
      }
  ngAfterViewInit()
  {
        }
        

}
