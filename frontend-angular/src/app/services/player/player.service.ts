import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from 'src/app/Models/Player';
import { environment } from 'src/environments/environment';
import { AuthService } from '../auth/auth.service';
@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  constructor(private http : HttpClient,private auth : AuthService) { }

  GetPlayersOfTeam() : Observable<any>{
    return this.http.get<Player[]>(environment.baseUrl + `Players/GetPlayersOfTeam?teamId=${this.auth.userLogged?.teamId}`);
  }
}
