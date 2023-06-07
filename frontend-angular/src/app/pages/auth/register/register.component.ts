import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';
import { passwordMatch } from 'src/app/validators/passwordMatch';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private formBuilder : FormBuilder,
    private auth : AuthService,
    private router : Router) { }

  form! : FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      'username': ['', Validators.required],
      'name': [''],
      'lastname': [''],
      'password': ['', Validators.required],
      'confirmPassword': ['', Validators.required],
      'email': ['', [Validators.email, Validators.required]]
    }, {
      validators: passwordMatch('password', 'confirmPassword')
    });
  }
  register(){
    this.auth.register(this.form.value).subscribe((res) => {
      this.router.navigate(['']);
      // Effettua il login automaticamente
      this.auth.login({username: this.form.value.username, password: this.form.value.password}).subscribe((res) => {
        console.log('Login effettuato automaticamente dopo la registrazione', this.form.value.username);
        this.auth.userLogged = res.result.user;
        console.log(this.auth.userLogged)
        localStorage.setItem('token',res.result.token);
        localStorage.setItem('currentUser', JSON.stringify(res.result.user) )
      });
    });
  }

}

