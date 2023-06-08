import { Component, OnInit } from '@angular/core';
import { Player } from 'src/app/Models/Player';
import { AuthService } from 'src/app/services/auth/auth.service';
import { PlayerService } from 'src/app/services/player/player.service';
import { SortEvent } from 'primeng/api';
@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  constructor(private playerService : PlayerService,authService : AuthService) { }

  isArray = Array.isArray;
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
  customSort(event: SortEvent) {
    event.data?.sort((data1, data2) => {
        let value1 = data1[event.field!];
        let value2 = data2[event.field!];
        let result = null;

        if (value1 == null && value2 != null) result = -1;
        else if (value1 != null && value2 == null) result = 1;
        else if (value1 == null && value2 == null) result = 0;
        else if (typeof value1 === 'string' && typeof value2 === 'string') result = value1.localeCompare(value2);
        else result = value1 < value2 ? -1 : value1 > value2 ? 1 : 0;

        return event.order! * result;
    });
}

}
