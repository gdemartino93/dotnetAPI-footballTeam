<script>
import { useAuthStore } from '../stores/auth';
export default{

  data() {
    return {
      authStore : useAuthStore(),
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
          <h1 v-if="authStore.user != null">
            Benvenuto {{ authStore.user.username }}
          </h1>
        <h2>Gestisci la tua squadra con eFootball</h2>

      </div>
    </div>
  </main>
</template>
