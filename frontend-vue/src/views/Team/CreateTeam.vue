<script>
import axios from 'axios';
import { useAuthStore } from '../../stores/auth';
export default{

  data() {
    return {
      authStore : useAuthStore(),
      form : {
        name : '',
        state : '',
        city : '',
        stadium : '',
        applicationUserId : ''
      }
    };
  },
  methods: {
    createTeam(data){
        axios.post('Teams/CreateTeam', {
            name : data.name,
            state : data.state,
            city : data.city,
            stadium : data.stadium,
            applicationUserId : this.authStore.user.id
        })
    }
  },
  
};
</script>
<template>
  <div class="container">
    <div class="row d-flex flex-column justify-content-center align-items-center">
        <form method="POST"  class="col-6 gap-4 mx-auto d-flex flex-column my-5" @submit.prevent="createTeam(form)">
          <InputText  type="text" placeholder="Nome team" v-model="form.name" />
          <InputText  type="text" placeholder="Stato" v-model="form.state" />
          <InputText  type="text" placeholder="Città" v-model="form.city" />
          <InputText  type="text" placeholder="Stadio" v-model="form.stadium" />
          <Button label="Crea team" type="submit" class="col-3" />
        </form>
    </div>
  </div>
</template>
