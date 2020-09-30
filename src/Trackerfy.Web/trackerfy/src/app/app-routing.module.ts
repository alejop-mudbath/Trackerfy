import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AuthCallbackComponent} from "./users/auth-callback/auth-callback.component";

const routes: Routes = [

  {
    path: 'callback', component: AuthCallbackComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
