import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthCallbackComponent} from "./auth-callback/auth-callback.component";
import {AuthService} from "./auth.service";
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {TokenInterceptor} from './token.interceptor';


@NgModule({
  declarations: [AuthCallbackComponent],
  imports: [
    CommonModule
  ],
  providers: [AuthService, {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }]
})
export class AuthModule {
}
