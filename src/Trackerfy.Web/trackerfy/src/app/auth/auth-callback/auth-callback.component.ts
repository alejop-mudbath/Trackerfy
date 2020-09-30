import {Component, OnInit} from '@angular/core';
import {AuthService} from "../auth.service";

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.sass']
})
export class AuthCallbackComponent implements OnInit {

  constructor(private auth: AuthService) {
  }

  ngOnInit(): void {
    this.auth.handleLoginCallback();
  }

}
