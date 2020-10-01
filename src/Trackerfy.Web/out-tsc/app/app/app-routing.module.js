import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from "./pages/home/home.component";
import { AuthCallbackComponent } from "./auth/auth-callback/auth-callback.component";
const routes = [
    { path: 'callback', component: AuthCallbackComponent },
    { path: 'home', component: HomeComponent },
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forRoot(routes)],
        exports: [RouterModule]
    })
], AppRoutingModule);
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map