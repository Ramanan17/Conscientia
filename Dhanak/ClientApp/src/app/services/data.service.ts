import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable(
 
)
export class DataService {

  constructor(public http:Http) { 

  }
getCategory()
{
   return this.http.get("/api/category").pipe(map((response: any) => response.json()));
}
addEvents(event)
{
  return this.http.post('/api/events',event).pipe(map((response: any) => response.json()));
}
editEvents(event,id)
{
  return this.http.put("/api/events/"+id,event).pipe(map((response: any) => response.json()));
}

getEvents()
{
  return this.http.get("/api/events").pipe(map((response: any) => response.json()));
}
getEvent(id)
{
  return this.http.get("/api/events/"+id).pipe(map((response: any) => response.json()));
}
getCategories(id)
{
  return this.http.get("/api/category/values/"+id).pipe(map((response: any) => response.json()));
}
}
