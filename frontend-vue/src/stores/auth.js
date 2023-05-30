import { defineStore } from "pinia";
import axios from "axios";

export const useAuthStore = defineStore("auth", {
    // nello state si ineriscono le variabili
    state: () => ({
        authUser: null,
        authErrorsRegister: [],
        authErrorsLogin :[],
    }),
    // nei getters si calcola il valore derivante dallo stato dell'applicazione per non ripetre codice.
    getters: {
        user: (state) => state.authUser,
        errors: (state) => state.authErrors,
    },
    // qui ci vanno le funzioni tra cui le chiamate API
    actions: {
        async register(data) {
            try {
              await axios.post('userauth/register', {
                username: data.username,
                name: data.name,
                lastname: data.lastname,
                password: data.password,
                confirmPassword: data.confirmPassword,
                email: data.email,
              });
              this.router.push('/');
            } catch (error) {
                this.authErrorsRegister = error.response.data.errorMessage[0];
            }
          },
          
        async login(data){
            try {
               await axios.post('userauth/login',{
                    username : data.username,
                    password : data.password
                });
                this.authUser = data;
                this.router.push('/');
            } catch (error) {
                this.authErrorsLogin = error.response.data.errorMessage[0]
            }
        },
        logout(){
            this.authUser = null;
            this.router.push = ('/');
            console.log("logout")
        }






    }
})