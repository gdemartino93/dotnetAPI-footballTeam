import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  formUser!: FormGroup;
  isFormDirty: boolean = false;

  constructor(private auth: AuthService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.formUser = this.fb.group({
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
}
