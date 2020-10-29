import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthenticationService) { 
    this.loginForm = fb.group({
      'username': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    });

    console.log(this.loginForm);
  }

  ngOnInit() {
  }

  login(){
    this.authService
      .login(this.loginForm.value)
      .subscribe();
  }

  get username (){
   return this.loginForm.get('username');
  }

  get password (){
    return this.loginForm.get('password');
   }
}