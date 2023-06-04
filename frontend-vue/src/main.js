import './assets/main.css'
import { createApp, markRaw } from 'vue'
import PrimeVue from 'primevue/config';
import { createPinia } from 'pinia'
import App from './App.vue'
import ToastPlugin from 'vue-toast-notification';
import TreeTable from 'primevue/treetable';
import Column from 'primevue/column';
import Button from "primevue/button"
import InputText from 'primevue/inputtext';
import Dropdown from 'primevue/dropdown';
import router from './router'
import axios from 'axios';
axios.defaults.baseURL = "https://localhost:7099/api/";
//theme
import "primevue/resources/themes/lara-light-indigo/theme.css";
import 'vue-toast-notification/dist/theme-sugar.css';
//core
import "primevue/resources/primevue.min.css";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import 'primeicons/primeicons.css';
const pinia = createPinia();
pinia.use(({store}) => {
    store.router = markRaw(router)
});

const app = createApp(App)
app.use(PrimeVue)
app.use(ToastPlugin,{
    position : 'top-right'
})
app.component('Button', Button)
app.component('InputText',InputText)
app.component('DropDown',Dropdown)
app.component("Column",Column)
app.component('TreeTable',TreeTable)
app.use(pinia)
app.use(router)

app.mount('#app')
