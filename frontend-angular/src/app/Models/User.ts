export interface User {
  id : string,
  username : string,
  email : string,
  name : string,
  lastname : string,
  teamId? : number,
  teamName? : string
}
export interface UserRegister{
  username : string,
  name : string,
  lastname : string,
  password : string,
  confirmPassword : string,
  email : string
}
export interface UserLogin{
  username : string,
  password : string
}
