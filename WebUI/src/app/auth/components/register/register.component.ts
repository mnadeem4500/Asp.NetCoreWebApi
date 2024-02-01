import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../_services/auth.service';
import { RegisterDto } from '../../_models/register-dto'; // Import the RegisterDto model

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup; // Declare a FormGroup

  constructor(private fb: FormBuilder, private authSrv: AuthService) {
    // Create the FormGroup and form controls with validators if needed
    this.registerForm = this.fb.group({
      username: [, Validators.required],
      email: [, [Validators.required, Validators.email]],
      password: [, Validators.required],
    });
  }

  ngOnInit() {
  }

  onSubmit() {
if (this.registerForm.invalid){

  console.log('Form is invalid');
  return;

}

    if (this.registerForm.valid) {
      // Extract values from the form
      const username = this.registerForm.controls['username'].value;
      const email = this.registerForm.controls['email'].value;
      const password = this.registerForm.controls['password'].value;

      // Create a RegisterDto object
      const registerDto: RegisterDto = {
        username: username,
        email: email,
        password: password
      };
    // Call the register method from the AuthService
      this.authSrv.register(registerDto).subscribe(
        res => {
          console.log(res);
          // Handle successful registration
        },
        err => {
          console.log(err);
          // Handle registration error
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }
}
