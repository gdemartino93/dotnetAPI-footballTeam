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
          <form @submit.prevent="authStore.register(form)" method="POST" class="col-6 gap-4 mx-auto d-flex flex-column">
          <InputText v-model="form.username" type="text" placeholder="Username" />
          <InputText v-model="form.name" type="text" placeholder="Nome" />
          <InputText v-model="form.lastname" type="text" placeholder="Cognome" />
          <InputText v-model="form.password" type="password" placeholder="Password" />
          <InputText v-model="form.confirmPassword" type="password" placeholder="Conferma Password" />
          <InputText v-model="form.email" type="email" placeholder="email" />
          <Button label="Login" type="submit" class="col-3" />
        </form>
      </div>
    </div>
  </main>
</template>
