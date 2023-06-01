import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Login from '../views/Auth/Login.vue'
import Register from '../views/Auth/Register.vue'
import UserProfile from '../views/UserProfile/UserProfile.vue'
import CreateTeam from '../views/Team/CreateTeam.vue'

import { useAuthStore } from '../stores/auth'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    },
    {
      path: '/login',
      name: 'login',
      component : Login
    },
    {
      path: '/register',
      name: 'register',
      component : Register
    },
    {
      path : '/profile',
      name : 'profile',
      component : UserProfile,
      meta: {
        requiresAuth : true,
      }
    },
    {
      path : '/createTeam',
      name : 'createTeam',
      component : CreateTeam
    }
  ]
})
router.beforeEach((to,from,next) => {
  const authStore = useAuthStore();
  if(to.meta.requiresAuth && !authStore.user){
    next('/');
  }else{
    next();
  }
})
export default router
