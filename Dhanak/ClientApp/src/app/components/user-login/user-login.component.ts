import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  isNewUser = true;
  email = '';
  password = '';
  errorMessage = '';
  error: { name: string, message: string } = { name: '', message: '' };
 
  resetPassword = false;
  constructor(public authService: AuthService, private router: Router) { }
  checkUserInfo() {
    if (this.authService.isUserEmailLoggedIn) {
      this.router.navigate(['/user'])
    }
  }
 
  clearErrorMessage() {
    this.errorMessage = '';
    this.error = { name: '', message: '' };
  }
 
  changeForm() {
    this.isNewUser = !this.isNewUser
  }
  onSignUp(): void {
    if (this.validateForm(this.email, this.password)) {
      this.authService.signUpWithEmail(this.email, this.password)
        .then(() => {
          this.router.navigate(['/user'])
        }).catch(_error => {
          this.error = _error
          this.router.navigate(['/'])
        })
    }
  }
  onLoginEmail(): void {
    if (this.validateForm(this.email, this.password)) {
      this.authService.loginWithEmail(this.email, this.password)
        .then(() => this.router.navigate(['/user']))
        .catch(_error => {
          this.error = _error
          this.router.navigate(['/'])
        })
    }
  }
  validateForm(email: string, password: string): boolean {
    // validate this.errorMessage
    if (email.length === 0) {
      this.errorMessage = 'Please enter Email!'
      return false
    }
 
    if (password.length === 0) {
      this.errorMessage = 'Please enter Password!'
      return false
    }
 
    if (password.length < 6) {
      this.errorMessage = 'Password should be at least 6 characters!'
      return false
    }
 
    this.errorMessage = ''
 
    return true
  }
  isValidMailFormat(email: string) {
    const EMAIL_REGEXP = /^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i;
 
    if ((email.length === 0) && (!EMAIL_REGEXP.test(email))) {
      return false;
    }
 
    return true;
  }
 
  sendResetEmail() {
    this.clearErrorMessage()
 
    this.authService.resetPassword(this.email)
      .then(() => this.resetPassword = true)
      .catch(_error => {
        this.error = _error
      })
  }
  ngOnInit() {
  }

}
