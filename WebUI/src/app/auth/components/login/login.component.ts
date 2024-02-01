
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../_services/auth.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup; // Declare a FormGroup

  constructor(private fb: FormBuilder, private authSrv: AuthService, private router: RouterModule) {
    // Create the FormGroup and form controls with validators if needed
    this.loginForm = this.fb.group({
      email: [, [Validators.required, Validators.email]],
      password: [, Validators.required],
    });
  }

  ngOnInit() {
  }



  onSubmit() {
    if (this.loginForm.invalid) {
      alert('Invalid form')
      return
    }

    let email = this.loginForm.controls['email'].value;
    let password = this.loginForm.controls['password'].value;

    this.authSrv.login({ password: password, username: email }).subscribe(res => {
      console.log(res);
      //session data store

      //redirect to home page
      // this.router.;
    }, err => {
      console.log(err);
    })
  }
}

