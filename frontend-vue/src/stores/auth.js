import { defineStore } from "pinia";
import axios from "axios";
import router from "../router";

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
              router.push('/')
            } catch (error) {
                this.authErrorsRegister = error.response.data.errorMessage[0];
            }
          },
          
        async login(data){
            try {
               const resLogin = await axios.post('userauth/login',{
                    username : data.username,
                    password : data.password
                }
                );
                let token = resLogin.data.result.token;
                let role = resLogin.data.result.role;
                 localStorage.setItem("token",token);
                 localStorage.setItem("role", role);
                 localStorage.setItem("user", data.username)

                this.authUser = data;

                // await axios.get(`userauth/getuser?username=${this.authUser.username}`)
                //     .then(res => {
                //         res = res.data;
                //         let userLogged = res.result;
                //         this.authUser = userLogged;
                //     })
                this.getUser();
                router.push('/')
            } catch (error) {
                 //this.authErrorsLogin = error.response.data.errorMessage[0]
            }
        },
        logout(){
            this.authUser = null;
            localStorage.removeItem("role");
            localStorage.removeItem("token");
            localStorage.removeItem("user");
            router.push('/')
            console.log("logout")
        },
        async getUser(){
            let username = localStorage.getItem("user");
            await axios.get(`userauth/getuser?username=${username}`)
                    .then(res => {
                        res = res.data;
                        let userLogged = res.result;
                        this.authUser = userLogged;
                    })
                    console.log(this.authUser)
        } 






    }
})