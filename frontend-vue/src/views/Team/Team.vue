<script>
import axios from 'axios';
import { useAuthStore } from '../../stores/auth';
export default{

  data() {
    return {
        authStore : useAuthStore(),
        players : [],
        team : {},

    };
  },
  methods: {
    getTeamWithPlayer(id){
        axios.get(`Teams/GetTeamOfUser?userId=${id}`)
            .then(res => {
                res = res.data;
                this.players = res.result.player;
                this.team = res.result;
                console.log("player",this.players)
                console.log('team',this.team)
                // console.log(res.result.player)
            })
    }

  },
  mounted(){
    this.getTeamWithPlayer(this.authStore.user.id)
   
  }
  
};
</script>
<template>
  <div class="container">
    <table class="table table-hover">
  <thead>
    <tr>
      <th scope="col">Nome</th>
      <th scope="col">Cognome</th>
      <th scope="col">Data di nascita</th>
      <th scope="col">Ruolo</th>
      <th scope="col">Scadenza di contratto</th>
      <th scope="col">Valore</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="player in players" :key="player.id">
      <th>{{ player.name }}</th>
      <td>{{ player.lastname }}</td>
      <td>{{ player.dateOfBirth }}</td>
      <td>{{ player.role }}</td>
      <td>{{ player.contractExpiration }}</td>
      <td>{{ player.value }}</td>
    </tr>

  </tbody>
</table>
  </div>

</template>
