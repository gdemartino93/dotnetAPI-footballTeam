import './assets/main.css'
import { createApp } from 'vue'
import PrimeVue from 'primevue/config';
import { createPinia } from 'pinia'
import App from './App.vue'
import Button from "primevue/button"
import router from './router'
//theme
import "primevue/resources/themes/lara-light-indigo/theme.css";     
//core
import "primevue/resources/primevue.min.css";
import 'bootstrap/dist/css/bootstrap.css'
const app = createApp(App)
app.use(PrimeVue)
app.component('Button', Button)

app.use(createPinia())
app.use(router)

app.mount('#app')
