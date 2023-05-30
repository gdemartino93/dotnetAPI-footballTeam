
<script>
import { useAuthStore } from '../../stores/auth';
export default{

  data() {
    return {
      authStore : useAuthStore(),
      form: {
        username : "",
        password : ""
      }
    };
  },
  methods: {
  },
  
};
</script>
<template>
  <main>
    <div class="container">
      <div class="row text-center">
        <h1>Login</h1>
        
        <span class="text-danger" v-if="authStore.authErrorsLogin.length > 0">
            {{ authStore.authErrorsLogin }}
        </span>
          <form method="POST" @submit.prevent="authStore.login(form)" class="col-6 gap-4 mx-auto d-flex flex-column">
          <InputText v-model="form.username" type="text" placeholder="Normal" />
          <InputText v-model="form.password" type="password" placeholder="Normal" />
          <Button label="Login" type="submit" class="col-3" />
        </form>
      </div>
    </div>
  </main>
</template>
