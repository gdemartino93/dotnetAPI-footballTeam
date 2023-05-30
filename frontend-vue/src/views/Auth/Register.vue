<script>
import { useAuthStore } from '../../stores/auth';
export default{
  data(){
    return {
      authStore : useAuthStore(),
      form: {
        username : '',
        name : '',
        lastname : '',
        password : '',
        confirmPassword : '',
        email : ''
      }
    };
  },
  methods: {

  }
}
</script>

<template>
  <main>
    <div class="container">
      <div class="row text-center">
        <h1>Registrazione</h1>
        <span class="text-danger" v-if="authStore.authErrorsRegister.length > 0">
          {{ (authStore.authErrorsRegister)}}
        </span>
        <form @submit.prevent="authStore.register(form)" method="POST">
          <input type="text" placeholder="Username" v-model="form.username">
          <input type="text" placeholder="Nome" v-model="form.name">
          <input type="text" placeholder="Cognome" v-model="form.lastname" >
          <input type="text" placeholder="password" v-model="form.password">
          <input type="text" placeholder="conferma password" v-model="form.confirmPassword">
          <input type="email" placeholder="email" v-model="form.email">
          <button type="submit">Registrati</button>
        </form>
      </div>
    </div>
  </main>
</template>
