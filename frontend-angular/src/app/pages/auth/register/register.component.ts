import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private formBuilder : FormBuilder) { }

  form! : FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      'username' : ['' , Validators.required],
      'name' : [''],
      'lastname' : [''],
      'password' : ['',Validators.required],
      'confirmPassword' : ['', Validators.required],
      'email' : ['', Validators.email]
    })
  }

}
