import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService,
               private formBuilder : FormBuilder,
               private router : Router
              ) { }

  formLogin! : FormGroup;
  login(){
    this.auth.login(this.formLogin.value).subscribe((res)=>{
      this.router.navigate([''])
      this.auth.userLogged = res.result.user;
      console.log(this.auth.userLogged)
      localStorage.setItem('token',res.result.token);
      localStorage.setItem('currentUser', JSON.stringify(res.result.user) )

    })
  }

  ngOnInit(): void {
    this.formLogin = this.formBuilder.group({
      'username' : ['',Validators.required],
      'password' : ['',Validators.required]
    })
  }

}
