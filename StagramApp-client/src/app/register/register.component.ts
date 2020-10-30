import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  regiterForm: FormGroup;
  constructor(private fb: FormBuilder,private authService: AuthenticationService) { 
                let pattern = '^[^@\\s]+@[^@\\s]+\\.[^@\\s]{2,}';
                this.regiterForm = this.fb.group({
      'username': ['', [Validators.required, Validators.minLength(6)]],
      'email':['', [Validators.required, Validators.pattern(pattern)]],
      'password':['', [Validators.required, Validators.minLength(8)]],
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