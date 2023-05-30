import './assets/main.css'
import { createApp, markRaw } from 'vue'
import PrimeVue from 'primevue/config';
import { createPinia } from 'pinia'
import App from './App.vue'
import Button from "primevue/button"
import router from './router'
import axios from 'axios';
axios.defaults.baseURL = "https://localhost:7099/api/";
//theme
import "primevue/resources/themes/lara-light-indigo/theme.css";     
//core
import "primevue/resources/primevue.min.css";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

const pinia = createPinia();
pinia.use(({store}) => {
    store.router = markRaw(router)
});

const app = createApp(App)
app.use(PrimeVue)
app.component('Button', Button)

app.use(pinia)
app.use(router)

app.mount('#app')
