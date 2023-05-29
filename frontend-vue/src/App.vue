<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/Header.vue'
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
