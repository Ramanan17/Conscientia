import { async } from '@angular/core/testing';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { AngularFireAuth } from 'angularfire2/auth';
import { auth } from 'firebase/app';

@Component({
  selector: 'app-passwordless-auth',
  templateUrl: './passwordless-auth.component.html',
  styleUrls: ['./passwordless-auth.component.css']
})
export class PasswordlessAuthComponent implements OnInit {

  user:Observable<any>;
  email:string;
  emailSent = false;
  errorMessage:string;
  constructor(public afauth:AngularFireAuth,private router:Router) { }

  ngOnInit() {

    this.user = this.afauth.authState;
    const url =this.router.url;
    this.confirmSignIn(url);
  }
  logingoogle()
  {
    this.afauth.auth.signInWithPopup(new auth.GoogleAuthProvider());
   
  }
  loginfb()
  {
    this.afauth.auth.signInWithPopup(new auth.FacebookAuthProvider());
  }
  logout()
  {
    this.afauth.auth.signOut();
  }
  async sendEmailLink()
  {
    const actionCodeSettings={
      url:"http://localhost:50456/Counter",
      handleCodeInApp:true
    }
    try {
      await this.afauth.auth.sendSignInLinkToEmail(
       this.email,
       actionCodeSettings
      );
      window.localStorage.setItem('emailForSignIn',this.email);
      this.emailSent=true;
    } catch (error) {
      this.errorMessage=error;
      
    }
  }
  async confirmSignIn(url)
  {
    try {
      if(this.afauth.auth.isSignInWithEmailLink(url))
      {
        let email = window.localStorage.getItem('emailForSignIn')
        if(!email)
        {
          email=window.prompt("Please provide a email for confirmation")
        }

        const result = await this.afauth.auth.signInWithEmailLink(email,url);
        window.localStorage.removeItem('emailForSignIn');
      }
    } catch (error) {
      this.errorMessage=error;
    }
  }

}
