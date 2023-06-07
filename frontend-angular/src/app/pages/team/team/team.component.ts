import { Component, OnInit } from '@angular/core';
import { Player } from 'src/app/Models/Player';
import { AuthService } from 'src/app/services/auth/auth.service';
import { PlayerService } from 'src/app/services/player/player.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  constructor(private playerService : PlayerService,authService : AuthService) { }

  players : Player[] = [];
  ngOnInit(): void {
    this.getPlayers()
  }

  getPlayers(){
    this.playerService.GetPlayersOfTeam().subscribe((res) => {
      this.players = res.result;
      console.log(this.players)
    })
  }

}
