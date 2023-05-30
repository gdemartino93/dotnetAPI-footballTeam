<template>
    <div class="container">
      <div class="row text-center">
        <h2>Questo è il tuo profilo</h2>
      </div>
      <span class="text-success" v-if="authStore.editSuccess == true">Modifica effettuata</span>
      <span class="text-danger" v-if="authStore.editSuccess == false">C'è stato un problema</span>

      <form @submit.prevent="editNameAndLastname">

        <input v-model="form.id" hidden type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" >
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Username</span>
            <input disabled v-model="form.username" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default">
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Email</span>
            <input disabled v-model="form.email" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default">
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Nome</span>
            <input v-model="form.name" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default">
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="inputGroup-sizing-default">Cognome</span>
            <input v-model="form.lastname" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default">
        </div>
        <Button label="Modifica" type="submit" class="col-2" />
      </form>
    </div>
  </template>
  
  <script>
  import router from '../../router';
import { useAuthStore } from '../../stores/auth';
  
  export default {
    data() {
      return {
        authStore: useAuthStore(),
        form: {
          id: '',
          username: '',
          name: '',
          lastname: '',
          email: ''
        }
      };
    },
    created() {
      this.form.id = this.authStore.user.id;
      this.form.username = this.authStore.user.username;
      this.form.name = this.authStore.user.name;
      this.form.lastname = this.authStore.user.lastname;
      this.form.email = this.authStore.user.email;
    },
    methods: {
        editNameAndLastname() {
            this.authStore.editSuccess = undefined; // Reimposta la variabile editSuccess su false
            this.authStore.EditNameAndLastname(this.form);
  }
    },
    
  };
  </script>
  
<style scoped>
form{
    margin-top: 50px;
}
</style>