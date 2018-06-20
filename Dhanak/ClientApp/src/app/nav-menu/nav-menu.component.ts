import { Router } from '@angular/router';
import { AuthService } from './../services/auth.service';
import { Component } from '@angular/core';
import { AngularFireAuth } from 'angularfire2/auth';
import { auth } from 'firebase/app';
import { Auth0Service } from '../services/auth0.service';



@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(public afAuth: AngularFireAuth,private route:Router,public auth:Auth0Service)
  {
    console.log(auth.isAuthenticated());
  }
  
  login()
  {
    this.route.navigate(['/data']);
  }
  logout()
  {
    this.afAuth.auth.signOut();
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
