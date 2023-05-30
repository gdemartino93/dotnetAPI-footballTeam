
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
        <form method="POST" @submit.prevent="authStore.login(form)">
            <input type="text" placeholder="username" v-model="form.username">
            <input type="text" placeholder="password" v-model="form.password">
            <button class="btn btn-success">Login</button>
        </form>
      </div>
    </div>
  </main>
</template>
