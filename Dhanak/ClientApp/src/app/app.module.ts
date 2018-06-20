import { Auth0Service } from './services/auth0.service';
import { ClientService } from './services/client.service';

import { EditEventComponent } from './components/edit-event/edit-event.component';
import { NewEventComponent } from './components/new-event/new-event.component';
import { DataTablesModule } from 'angular-datatables';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {HttpModule} from '@angular/http'
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DataService } from './services/data.service';
import { DatatableComponent } from './datatable/datatable.component';
import { EventComponent } from './components/event/event.component';
import { AuthService } from './services/auth.service';
import {AngularFireModule} from 'angularfire2';
import {AngularFireDatabase} from 'angularfire2/database';
import {AngularFireAuth} from 'angularfire2/auth';
import { AngularFireDatabaseModule } from 'angularfire2/database';
import { AngularFireAuthModule } from 'angularfire2/auth';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { PasswordlessAuthComponent } from './components/passwordless-auth/passwordless-auth.component';

export const firebaseConfig ={
  apiKey: 'AIzaSyBTLixnmrPVB9x9EM3ilJb0rAmFQlLfKN0',
    authDomain: 'dhanak-cfdad.firebaseapp.com',
    databaseURL: 'https://dhanak-cfdad.firebaseio.com',
    projectId: 'dhanak-cfdad',
    storageBucket: 'dhanak-cfdad.appspot.com',
    messagingSenderId: '70648789644'
};
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NewEventComponent,
    EditEventComponent,
    DatatableComponent,
    EventComponent,
    UserLoginComponent,
    UserInfoComponent,
    PasswordlessAuthComponent,
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpModule,
    HttpClientModule,
    DataTablesModule,
    FormsModule,
    AngularFireDatabaseModule ,
    AngularFireAuthModule,
    AngularFireModule.initializeApp(firebaseConfig),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {path:'new',component:NewEventComponent},
      {path:'edit/:id',component:EditEventComponent},
      {path:'data',component:DatatableComponent},
      {path:'login',component:PasswordlessAuthComponent},
      {path:'user',component:UserInfoComponent}
    ])
  ],
  providers: [DataService,AuthService,AngularFireAuth,AngularFireDatabase,ClientService,Auth0Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
