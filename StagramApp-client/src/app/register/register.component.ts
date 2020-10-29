import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  regiterForm: FormGroup;
  constructor(private fb: FormBuilder,
              private authService: AuthenticationService) { 
    this.regiterForm = this.fb.group({
      'username': ['', [Validators.required]],
      'email':['', [Validators.required]],
      'password':['', [Validators.required]],
      'confirmPassword':['', [Validators.required]]
    });
  }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.regiterForm.value);
  }

  get username(){
    return this.regiterForm.get('username');
  }

  get email(){
    return this.regiterForm.get('email');
  }

  get password(){
    return this.regiterForm.get('password');
  }

  get confirmPassword(){
    return this.regiterForm.get('confirmPassword');
  }
}