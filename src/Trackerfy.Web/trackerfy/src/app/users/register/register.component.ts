import {Component, OnInit} from '@angular/core';
import {finalize} from "rxjs/operators";
import {RegisterUser} from "./user-register.model";
import {AuthService} from "../../auth/auth.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  userRegistration: RegisterUser = {name: '', email: '', password: ''};
  submitted: boolean = false;

  constructor(private authService: AuthService) {

  }

  ngOnInit() {
  }

  onSubmit() {
    this.authService.register(this.userRegistration)
      .pipe(finalize(() => {
      }))
      .subscribe(() => {
          this.success = true;
        },
        error => {
          this.error = error;
        });
  }
}
