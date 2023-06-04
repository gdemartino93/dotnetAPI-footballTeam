<script>
import { useAuthStore } from '../stores/auth';
export default {
    data(){
        return {
            auth : useAuthStore(),
            showDropdown: false
        }
    },
    

}
</script>

<style scoped>
li a{
    text-decoration: none;
    color: inherit;
}
.auth{
    margin-right: 150px;
    margin-left: 10px;
}
</style>
<template>
<nav class="navbar navbar-expand-lg bg-success">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">eFootball</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item mx-2">
            <RouterLink to="/">Home</RouterLink>
        </li>
        <li class="nav-item">
            <RouterLink to="/about">About</RouterLink>
        </li>
        


      </ul>
      <div class="d-flex">

        <form class="d-flex" role="search">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline-warning" type="submit">Search</button>
      </form>
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
      <li class="nav-item dropdown auth" v-if="auth.user == null">
          <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
            Accesso
          </a>
          <ul class="dropdown-menu" >
            <li>
                <RouterLink class="dropdown-item" to="/login">Login</RouterLink>
            </li>
            <li>
                <RouterLink class="dropdown-item" to="/register">Register</RouterLink>
            </li>
            <!-- <li><a class="dropdown-item" href="#">Something else here</a></li> -->
          </ul>
        </li>
        <div class="dropdown auth" v-if="auth.user">
          <Button icon="pi pi-user" class="dropdown-toggle" severity="warning" rounded outlined aria-label="User"  data-bs-toggle="dropdown" aria-expanded="false"></Button> 

          <ul class="dropdown-menu">
            <li>
              <RouterLink class="dropdown-item" to="/createteam" v-if="auth.user.teamName == null">Crea team</RouterLink>
              <RouterLink class="dropdown-item" to="/team" v-else>{{ auth.user.teamName }}</RouterLink>
            </li>
            <li>
              <RouterLink class="dropdown-item" to="/profile">Profilo</RouterLink>
            </li>
            <li>
                <a class="dropdown-item" @click="auth.logout">Logout</a>
            </li>
          </ul>
        </div>  

      </ul>
      </div>
      
    </div>
  </div>
</nav>
</template>
