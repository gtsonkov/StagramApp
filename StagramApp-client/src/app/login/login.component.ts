import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder) { 
    this.loginForm = fb.group({
      'username': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    });

    console.log(this.loginForm);
  }

  ngOnInit() {
  }

  login(){
    console.log(this.loginForm.value);
  }

  get username (){
   return this.loginForm.get('username');
  }

  get password (){
    return this.loginForm.get('password');
   }
}