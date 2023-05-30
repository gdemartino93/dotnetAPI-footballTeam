<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/Header.vue';
import { useAuthStore } from './stores/auth';
const authStore = useAuthStore();
try {
  authStore.getUser(); //eseguiamo al mounted dell'applicazione la funzione per tenere traccia se l'utente è loggato
  console.log(authStore.user)
} catch (error) {
  console.log("Errore",error)
}

</script>

<template>
  <header>

    <div class="wrapper">
    

      <nav>
        <Header></Header>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<style scoped>

</style>
