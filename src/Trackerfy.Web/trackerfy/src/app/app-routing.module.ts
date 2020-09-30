import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AuthCallbackComponent} from "./users/auth-callback/auth-callback.component";
import {HomeComponent} from "./pages/home/home.component";

const routes: Routes = [
  {path: 'callback', component: AuthCallbackComponent},
  {path: 'home', component: HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
