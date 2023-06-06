import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User, UserLogin, UserRegister } from 'src/app/Models/User';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient) {
    console.log('auth service')
    this.userLogged = JSON.parse(localStorage.getItem('currentUser') || '{}');
    console.log(this.userLogged)
  }

  userLogged? : User;

  register(user : UserRegister): Observable<any>{
    return this.http.post<any>(environment.baseUrl + 'userauth/register' ,user);
  }
  login(user : UserLogin): Observable<any>{
    return this.http.post<any>(environment.baseUrl + 'userauth/login',user);
  }
  getIsLogged(): boolean {
    const logged = localStorage.getItem('currentUser');
    return logged ? true : false
  }


}
