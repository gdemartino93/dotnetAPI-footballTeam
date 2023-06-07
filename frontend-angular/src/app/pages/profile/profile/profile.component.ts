import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  formUser!: FormGroup;
  isFormDirty: boolean = false;

  constructor(private auth: AuthService,
               private fb: FormBuilder,
               private router : Router) {}

  ngOnInit(): void {
    this.formUser = this.fb.group({
      id : [this.auth.userLogged?.id],
      username: [this.auth.userLogged?.username],
      name: [this.auth.userLogged?.name],
      lastname: [this.auth.userLogged?.lastname],
      email: [this.auth.userLogged?.email]
    });
    this.formUser.valueChanges.subscribe(() => {
      this.isFormDirty = true;
    });
  }

  resetForm(): void {
    this.formUser.patchValue({
      username: this.auth.userLogged?.username,
      name: this.auth.userLogged?.name,
      lastname: this.auth.userLogged?.lastname,
      email: this.auth.userLogged?.email
    });
    this.isFormDirty = false;
  }
  editUserProfile() : void {
    this.auth.changeData(this.formUser.value).subscribe((res)=> {
      this.auth.getUser(this.auth.userLogged!.username)
      this.auth.userLogged!.email = this.formUser.value.email;
      this.auth.userLogged!.lastname = this.formUser.value.lastname;
      this.auth.userLogged!.name = this.formUser.value.name;
      this.router.navigate([''])
    })
  }
}
