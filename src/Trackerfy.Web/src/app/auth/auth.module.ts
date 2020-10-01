import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthCallbackComponent} from "./auth-callback/auth-callback.component";
import {AuthService} from "./auth.service";


@NgModule({
  declarations: [AuthCallbackComponent],
  imports: [
    CommonModule
  ],
  providers: [AuthService]
})
export class AuthModule {
}
