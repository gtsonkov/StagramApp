import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  regiterForm: FormGroup;
  constructor(private fb: FormBuilder) { 
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