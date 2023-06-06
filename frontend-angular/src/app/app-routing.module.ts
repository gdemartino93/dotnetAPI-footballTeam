import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { TeamComponent } from './pages/team/team/team.component';
import { LoggedGuard } from './guard/logged.guard';
import { ProfileComponent } from './pages/profile/profile/profile.component';
const routes: Routes = [
  {
    path : '',
    component : HomeComponent
  },
  {
    path : 'login',
    component : LoginComponent
  },
  {
    path : 'register',
    component : RegisterComponent
  },
  {
    path : 'team',
    component : TeamComponent,
    canActivate : [LoggedGuard]
  },
  {
    path : 'profile',
    component : ProfileComponent,
    canActivate : [LoggedGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
