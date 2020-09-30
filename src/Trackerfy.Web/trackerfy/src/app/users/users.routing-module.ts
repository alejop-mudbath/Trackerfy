import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {RegisterComponent} from './register/register.component';
import {Shell} from '../shell/shell.service';
import {AuthCallbackComponent} from "./auth-callback/auth-callback.component";

const routes: Routes = [
  Shell.childRoutes([
    {
      path: 'register', component: RegisterComponent
    },
    {
      path: 'callback', component: AuthCallbackComponent
    }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class UsersRoutingModule {
}
