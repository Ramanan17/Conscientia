// src/app/auth/auth.service.ts

import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import * as firebase from 'firebase/app';
import { AngularFireAuth } from 'angularfire2/auth';
import { Observable } from 'rxjs';
import { GoogleAuthProvider, FacebookAuthProvider } from '@firebase/auth-types';

(window as any).global = window;

@Injectable()
export class AuthService {

  authState: any = null;
 

  constructor(public router: Router,private afAuth: AngularFireAuth) {
    this.afAuth.authState.subscribe((auth) => {
      this.authState = auth
    });
   
   
  }
  resetPassword(email: string) {
    var auth = firebase.auth();
    return auth.sendPasswordResetEmail(email)
      .then(() => console.log("email sent"))
      .catch((error) => console.log(error))
  }
  get isUserAnonymousLoggedIn(): boolean {
    return (this.authState !== null) ? this.authState.isAnonymous : false
  }
  get currentUserId(): string {
    return (this.authState !== null) ? this.authState.uid : ''
  }
  get currentUserName(): string {
    return this.authState['email']
  }
  get currentUser(): any {
    return (this.authState !== null) ? this.authState : null;
  }
 
  get isUserEmailLoggedIn(): boolean {
    if ((this.authState !== null) && (!this.isUserAnonymousLoggedIn)) {
      return true
    } else {
      return false
    }
  }
  signUpWithEmail(email: string, password: string) {
    return this.afAuth.auth.createUserWithEmailAndPassword(email, password)
      .then((user) => {
        this.authState = user
      })
      .catch(error => {
        console.log(error)
        throw error
      });
  }
  loginWithEmail(email: string, password: string) {
    return this.afAuth.auth.signInWithEmailAndPassword(email, password)
      .then((user) => {
        this.authState = user
      })
      .catch(error => {
        console.log(error)
        throw error
      });
  }
  signOut(): void {
    this.afAuth.auth.signOut();
    this.router.navigate(['/'])
  }

  

}
